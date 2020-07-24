using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    public GameObject DeathScreen; //reference to the death screen
    public Slider healthBar;
    public Image healthColor;
    public float healthColorNumberRed;
    public float healthColorNumberYellow;

    public int Health;

    float healthPercent;

    private void Update()
    {

        if (healthBar.value >= Health)
        {
            healthBar.value -= .1f;

            healthColor.color = new Color(healthColorNumberRed, healthColorNumberYellow, healthColor.color.b, 1f);;
        }
    }

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

        healthColorNumberRed += .1f;

        if (Health <= 15)
        {
            healthColorNumberYellow -= .1f;
        }
    }

    void Death()
    {
        Audio audio = GetComponent<Audio>();
        audio.PlayDeath();

        DeathScreen.active = true;
        Time.timeScale = 0;


        //gameObject.SetActive(false); 
    }
}
