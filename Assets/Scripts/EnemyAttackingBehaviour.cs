﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingBehaviour : MonoBehaviour 
{

	public Transform player;
	public float enemyRange = 20;
	public float enemyDamage = 20;
	private bool canAttack = true;
    private PlayerHealth playerHealth;
    Animator anim;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (canAttack)
		{
			if(Vector3.Distance(player.position,transform.position) < enemyRange)
			{
                anim.SetTrigger("Attack");
				canAttack = false;
				StartCoroutine(PerformAttack());
			}
            anim.SetTrigger("Walk");
		}
	}

	private IEnumerator PerformAttack()
	{
		playerHealth.DecreaseHealth(enemyDamage);
		yield return new WaitForSeconds(1.5f);
		
		canAttack = true;
	}
}
