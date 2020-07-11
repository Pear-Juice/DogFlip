using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handgun : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    public float weaponForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            rb.AddForce(-transform.forward * weaponForce, ForceMode.Impulse);
        }
    }
}
