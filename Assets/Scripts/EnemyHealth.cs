using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth = 100f;
	
	[SerializeField] private float health = 0;
	
	// Use this for initialization
	void Start () {
		health = maxHealth;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int damagePerShot, Vector3 shootHitPoint)
	{
		health -= damagePerShot;
		
		if(health <= 0)
			Destroy(this.gameObject);
	}
}
