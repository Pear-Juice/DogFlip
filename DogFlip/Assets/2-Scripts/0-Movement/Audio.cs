using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioClip grappleShoot;
    public AudioClip grappleReel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PlayGrapple()
    {
        GetComponent<AudioSource>().PlayOneShot(grappleReel);
        GetComponent<AudioSource>().PlayOneShot(grappleShoot);
    }
}
