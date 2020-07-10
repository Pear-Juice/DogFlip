using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    public GameObject endOfGrappleGun;
    public GameObject endOfHook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;

        if (Physics.Raycast(endOfGrappleGun.transform.position, transform.localToWorldMatrix * Vector3.left * 200, out Hit))
        {
            if (Hit.transform.gameObject.tag == "Grappleable" && Input.GetMouseButtonDown(1))
            {
                Debug.Log("Grapple");
                Instantiate(endOfHook);
            }
        }


        Debug.DrawRay(endOfGrappleGun.transform.position, transform.localToWorldMatrix * Vector3.left * 100,Color.white);
    }
}
