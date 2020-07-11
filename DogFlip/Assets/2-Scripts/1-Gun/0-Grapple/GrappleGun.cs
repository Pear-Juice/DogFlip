using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    public GameObject endOfGrappleGun;
    public GameObject endOfHook;
    public int force = 0;
    public Rigidbody rb;

    bool grappleWall;
    bool grappleObject;
    bool grappleEnemy;

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

        if (Physics.Raycast(transform.position, transform.localToWorldMatrix * Vector3.back * 200, out Hit))
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (Hit.transform.gameObject.tag == "Grappleable")
                {
                    Debug.Log("GrappleWall");
                    hook = Instantiate(endOfHook, Hit.point, Hit.transform.rotation);

                    grappleWall = true;
                }

                if (Hit.transform.gameObject.tag == "Object")
                {
                    Debug.Log("GrappleObject");
                    hook = Instantiate(endOfHook, Hit.point, Hit.transform.rotation);

                    grappleObject = true;
                }

                if (Hit.transform.gameObject.tag == "Enemy")
                {
                    Debug.Log("GrappleEnemy");
                    hook = Instantiate(endOfHook, Hit.point, Hit.transform.rotation);

                    grappleEnemy = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Destroy(hook);
            grappleWall = false;
            grappleEnemy = false;
            grappleObject = false;
        }


        Debug.DrawRay(transform.position, transform.localToWorldMatrix * Vector3.back * 100,Color.white);
    }

    private void FixedUpdate()
    {
        if (grappleWall)
        {
            rb.AddExplosionForce(-force, hook.transform.position, 200);
        }

        if (grappleObject)
        {
            rb.AddExplosionForce(-force, hook.transform.position, 200);
        }
        
        if (grappleEnemy)
        {
            rb.AddExplosionForce(-force, hook.transform.position, 200);
        }


    }
}
