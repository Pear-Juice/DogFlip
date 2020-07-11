using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject EnemyObject;

    public int Health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Debug.Log("Shot");

            TakeDamage();
        }
    }

    void TakeDamage()
    {
        Enemy enemy = EnemyObject.GetComponent<Enemy>();
        Health -= enemy.Damage;

        if (Health <= 0)
            Death();
    }

    void Death()
    {
        if (this.gameObject != null)
            Destroy(this.gameObject);
    }
}
