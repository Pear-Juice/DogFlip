using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    public GameObject endOfGrappleGun;
    public GameObject endOfHook;
    public GameObject sharkHook;
    public int force = 0;
    public Rigidbody rb;

    bool grappleWall;
    bool grappleObject;
    bool grappleEnemy;
    bool grappleLetGo;
    bool grappleGrab;


    int grappleWallOnce = 0;
    int grappleEnemyOnce = 0;
    int grappleObjectOnce = 0;

    GameObject grappledObject;

    GameObject hook;

	LineRenderer grappleLR; // grapple tether line renderer

    private void Awake() {
		grappleLR = endOfGrappleGun.GetComponent<LineRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;

        if (Physics.BoxCast(transform.position, new Vector3(.1f, .1f, .5f), -transform.forward * 200, out Hit))
        {
            if (Input.GetMouseButtonDown(1))
            {
                Audio audio = GetComponent<Audio>();
                audio.PlayGrapple();

                audio.StartReel();


				grappleLR.enabled = true;
				if (Hit.transform.gameObject.tag == "Grappleable")
                {
                    Debug.Log("GrappleWall");
                    hook = Instantiate(endOfHook, Hit.point, Hit.transform.rotation);

                    grappleLetGo = false;
                    grappleWall = true;
                }

                if (Hit.transform.gameObject.tag == "Object")
                {
                    Debug.Log("GrappleObject");
                    hook = Instantiate(endOfHook, Hit.transform.position, Hit.transform.rotation);

                    grappleLetGo = false;
                    grappleObject = true;
                }

                if (Hit.transform.gameObject.tag == "Enemy")
                {
                    Debug.Log("GrappleEnemy");
                    hook = Instantiate(endOfHook, Hit.transform.position, Hit.transform.rotation);

                    grappleLetGo = false;
                    grappleEnemy = true;
                }
            }

            if (grappleEnemy)
            {
                hook.transform.position = grappledObject.transform.position;
            }

            if (grappleObject)
            {
                hook.transform.position = grappledObject.transform.position;
            }

            grappledObject = Hit.transform.gameObject;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Destroy(hook);
            grappleWall = false;
            grappleEnemy = false;
            grappleObject = false;

            grappleLetGo = true;

			grappleLR.enabled = false;

            Audio audio = GetComponent<Audio>();
            audio.StopReel();
            audio.PlayGrappleReset();

            grappleWallOnce = 0;
            grappleEnemyOnce = 0;
            grappleObjectOnce = 0;

            grappleGrab = false;
        }

        if (grappleLetGo)
        {
            sharkHook.transform.position = Vector3.MoveTowards(sharkHook.transform.position, endOfGrappleGun.transform.position, 100 * Time.deltaTime);
        }

        Debug.DrawRay(transform.position, transform.localToWorldMatrix * Vector3.back * 100,Color.white);
    }

    private void FixedUpdate()
    {
        Audio audio = GetComponent<Audio>();

        if (grappleWall)
        {
            sharkHook.transform.position = Vector3.MoveTowards(sharkHook.transform.position, hook.transform.position, 150 * Time.deltaTime);
            

            if (sharkHook.transform.position == hook.transform.position)
            {
                grappleGrab = true;
            }

            if (grappleGrab)
            {
                rb.AddExplosionForce(-force, hook.transform.position, 200);

                grappleWallOnce++;
            }
        }
                

        if (grappleObject)
        {
            sharkHook.transform.position = Vector3.MoveTowards(sharkHook.transform.position, hook.transform.position, 150 * Time.deltaTime);

            Rigidbody pb = grappledObject.GetComponent<Rigidbody>();

            if (sharkHook.transform.position == hook.transform.position && pb)
            {
                grappleGrab = true;
            }

            if (grappleGrab)
            {
                pb.AddExplosionForce(-force, transform.position, 200);

                rb.AddExplosionForce(-force, hook.transform.position, 200);

                grappleObjectOnce++;
            }
        }
        
        if (grappleEnemy)
        {
            sharkHook.transform.position = Vector3.MoveTowards(sharkHook.transform.position, hook.transform.position, 150 * Time.deltaTime);

            Rigidbody pb = grappledObject.GetComponent<Rigidbody>();

            if (sharkHook.transform.position == hook.transform.position && pb)
            {
                grappleGrab = true;
            }

            if (grappleGrab)
            {
                pb.AddExplosionForce(-force, transform.position, 200);

                rb.AddExplosionForce(-force, hook.transform.position, 200);

                grappleEnemyOnce++;
            }
        }

        Debug.Log(grappleGrab);

        if (grappleWall || grappleObject || grappleEnemy) { // if grappling anything grappleable
			Vector3[] tetherPositions = new Vector3[] { endOfGrappleGun.transform.position, sharkHook.transform.position }; // get tether endpoints
			grappleLR.SetPositions(tetherPositions); // apply new positions for tether line renderer
		}

        if (grappleWallOnce == 1)
            audio.PlayGrappleHitWall();

        if (grappleEnemyOnce == 1)
            audio.PlayGrappleHitEnemy();

        if (grappleObjectOnce == 1)
            audio.PlayGrappleHitObject();
    }
}
