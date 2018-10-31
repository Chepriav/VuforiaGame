using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth = 100f;
    public int scoreValue = 10;             //Puntos al matar al enemigo.

    [SerializeField] private float health = 0;

    Animator anim;
    
	// Use this for initialization
	void Awake () {
		health = maxHealth;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int damagePerShot, Vector3 shootHitPoint)
	{
		health -= damagePerShot;
        if (health <= 0)
        {
            Death();
        }
	}

    void Death()
    {
        anim.SetTrigger("Dead");

        ScoreManager.score += scoreValue;
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }
}
