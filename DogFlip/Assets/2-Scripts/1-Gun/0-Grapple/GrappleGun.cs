using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    public GameObject endOfGrapple;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;

        if (Physics.Raycast(endOfGrapple.transform.position,endOfGrapple.transform.localRotation.eulerAngles,out Hit,20))
        {
            if (Hit.transform.gameObject.tag == "Grappleable")
            {
                Debug.Log("can grapple");
            }
        }


        Debug.DrawRay(endOfGrapple.transform.position, endOfGrapple.transform.localRotation.eulerAngles, Color.white,20);
    }
}
