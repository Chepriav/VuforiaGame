using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	
	public float MaxHeatlh;
	
	private float health;

	private void Start()
	{
		health = MaxHeatlh;
	}

	public void DecreaseHealth(float amount)
	{
		health -= amount;
		
		if(health <= 0)
			SceneManager.LoadScene("Menu");
	}
}
