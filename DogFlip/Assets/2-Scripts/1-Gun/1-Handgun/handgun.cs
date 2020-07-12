using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handgun : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
	ParticleSystem ps;

    public int Damage;
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

            Audio audio = player.GetComponent<Audio>();
            audio.PlayShoot();
        }


        
    }

    private void OnParticleCollision(GameObject other) {
		if (other.tag == "Enemy") {

            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.OnHit(Damage);
            }
        
		}
	}
}
