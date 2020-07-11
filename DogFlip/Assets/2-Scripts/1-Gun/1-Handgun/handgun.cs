using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handgun : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
	ParticleSystem ps;
	public float weaponForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
		ps = GetComponentInChildren<ParticleSystem>();
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
			ps.Emit(1);
			rb.AddForce(-transform.forward * weaponForce, ForceMode.Impulse);
        }
    }

    private void OnParticleCollision(GameObject other) {
		if (other.tag == "Enemy") {
			Debug.Log("Hit Enemy"); // todo: make enemy react
		}
	}
}
