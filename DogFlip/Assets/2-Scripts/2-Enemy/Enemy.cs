using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int Damage;

	public GameObject explosionPrefab;

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
		GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
		Destroy(explosion, 3f);
	}
}
