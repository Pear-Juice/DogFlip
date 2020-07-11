using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OnHit(int Damage)
    {
        Debug.Log("Hit Enemy");

        Health -= Damage;

        Debug.Log(Health);

        if (Health <= 0)
            Death();
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
