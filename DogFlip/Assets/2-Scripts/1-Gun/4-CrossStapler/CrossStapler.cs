using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossStapler : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    ParticleSystem ps;

    public Sprite pulledBackBow;
    public Sprite Bow;

    public int Damage;
    public float waitTime;
    public float weaponForce = 10;

    bool isPulledBack;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        ps = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(pullBack());
        }

        if (Input.GetMouseButtonUp(0) && isPulledBack)
        {
            ps.Emit(1);
            rb.AddForce(-transform.forward * weaponForce, ForceMode.Impulse);

            Audio audio = player.GetComponent<Audio>();
            audio.PlayShoot();

            isPulledBack = false;
        }

        if (isPulledBack)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = pulledBackBow;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().sprite = Bow;
        }
    }

    IEnumerator pullBack()
    {
        yield return new WaitForSeconds(waitTime);

        isPulledBack = true;
    }

    

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {

            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.OnHit(Damage);
            }

        }
    }
}

