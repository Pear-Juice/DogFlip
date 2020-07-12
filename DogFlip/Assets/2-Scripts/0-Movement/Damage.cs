using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public GameObject DeathScreen; //reference to the death screen

    public int Health;

    public void TakeDamage(int damage)
    {
        Audio audio = GetComponent<Audio>();

        Health -= damage;

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

        DeathScreen.active = true;

        //gameObject.SetActive(false); 
    }
}
