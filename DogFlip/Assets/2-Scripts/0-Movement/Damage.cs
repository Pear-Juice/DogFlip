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
        Audio audio = GetComponent<Audio>();

        Enemy enemy = EnemyObject.GetComponent<Enemy>();
        Health -= enemy.Damage;

        if (Health <= 0)
            Death();

        if (Health > 0)
        {
            audio.PlayHit();
        }
    }

    void Death()
    {
        Audio audio = GetComponent<Audio>();
        audio.PlayDeath();

        //gameObject.SetActive(false); 
    }
}
