using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Damage damageScript = other.gameObject.GetComponent<Damage>();

            damageScript.TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }
}
