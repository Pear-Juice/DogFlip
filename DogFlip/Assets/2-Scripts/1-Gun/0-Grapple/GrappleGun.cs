using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    public GameObject endOfGrappleGun;
    public GameObject endOfHook;
    public int force = 0;
    public Rigidbody rb;

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
            if (Hit.transform.gameObject.tag == "Grappleable" && Input.GetMouseButtonDown(1))
            {
                Debug.Log("Grapple");
                hook = Instantiate(endOfHook, Hit.point, Hit.transform.rotation);

                
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Destroy(hook);
        }


        Debug.DrawRay(transform.position, transform.localToWorldMatrix * Vector3.back * 100,Color.white);
    }

    private void FixedUpdate()
    {
        if (hook != null)
        {
            rb.AddExplosionForce(-force, hook.transform.position, 200);
        }
    }
}
