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

    GameObject grappledObject;

    GameObject hook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;

        if (Physics.BoxCast(transform.position, new Vector3(.1f, .1f, .5f), -transform.forward * 200, out Hit))
        {
            if (Input.GetMouseButtonDown(1))
            {
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

                    grappleObject = true;
                }

                if (Hit.transform.gameObject.tag == "Enemy")
                {
                    Debug.Log("GrappleEnemy");
                    hook = Instantiate(endOfHook, Hit.transform.position, Hit.transform.rotation);

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
            
        }

        if (grappleLetGo)
        {
            sharkHook.transform.position = Vector3.MoveTowards(sharkHook.transform.position, endOfGrappleGun.transform.position, 100 * Time.deltaTime);
        }


        Debug.DrawRay(transform.position, transform.localToWorldMatrix * Vector3.back * 100,Color.white);
    }

    private void FixedUpdate()
    {
        if (grappleWall)
        {
            sharkHook.transform.position = Vector3.MoveTowards(sharkHook.transform.position, hook.transform.position, 150 * Time.deltaTime);

            if (sharkHook.transform.position == hook.transform.position)
                rb.AddExplosionForce(-force, hook.transform.position, 200);
        }

        if (grappleObject)
        {
            Rigidbody rb = grappledObject.GetComponent<Rigidbody>();
            if(rb) rb.AddExplosionForce(-force, transform.position, 200); // checks that grappleObject has rigidbody before applying force
        }
        
        if (grappleEnemy)
        {
			Rigidbody rb = grappledObject.GetComponent<Rigidbody>();
            if(rb) rb.AddExplosionForce(-force, transform.position, 200); // checks that grappleObject has rigidbody before applying force
		}


    }
}
