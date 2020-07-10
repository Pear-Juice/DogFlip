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

        if (Physics.Raycast(endOfGrapple.transform.position, new Vector3(
            endOfGrapple.transform.localRotation.x,
            endOfGrapple.transform.localRotation.y,
            endOfGrapple.transform.localRotation.z), out Hit, 1))
        {
            if (Hit.transform.gameObject.tag == "Grappleable")
            {
                Debug.Log("can grapple");
            }
        }

    }
}
