using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioClip grappleShoot;
    public AudioClip grappleReel;
    public AudioClip grappleReset;
    public AudioClip grappleHitWall;
    public AudioClip grappleHitEnemy;
    public AudioClip grappleHitObject;

    public AudioClip[] hit;

    public AudioClip[] death;

    public AudioClip shootGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PlayGrapple()
    {
        GetComponent<AudioSource>().PlayOneShot(grappleShoot);
    }

    public void StartReel()
    {
        GetComponent<AudioSource>().PlayOneShot(grappleReel);
    }

    public void StopReel()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void PlayGrappleReset()
    {
        GetComponent<AudioSource>().PlayOneShot(grappleReset);
    }

    public void PlayGrappleHitWall()
    {
        GetComponent<AudioSource>().PlayOneShot(grappleHitWall);
    }

    public void PlayGrappleHitEnemy()
    {
        GetComponent<AudioSource>().PlayOneShot(grappleHitEnemy);
    }

    public void PlayGrappleHitObject()
    {
        GetComponent<AudioSource>().PlayOneShot(grappleHitObject);
    }

    public void PlayHit()
    {
        GetComponent<AudioSource>().PlayOneShot(hit[Random.Range(0,6)]);
    }

    public void PlayDeath()
    {
        GetComponent<AudioSource>().PlayOneShot(death[Random.Range(0, 2)]);
    }

    public void PlayShoot()
    {
        GetComponent<AudioSource>().PlayOneShot(shootGun);
    }
}
