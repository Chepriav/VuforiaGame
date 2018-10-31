using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnerBehaviour : MonoBehaviour
{

	public GameObject EnemyPrefab;
	public Transform player;
	public float spawnTime = 5.0f;
	public bool hasImageBeenFound = false;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private IEnumerator IncreaseDifficulty()
	{
		while (true)
		{
			yield return new WaitForSeconds(2.0f);
			if (spawnTime <= 1.0f)
				yield return null;
			else
				spawnTime -= 1.0f;
			

		}
	}

	private void OnEnable()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		StartCoroutine(IncreaseDifficulty());

		if(hasImageBeenFound)
			StartCoroutine(SpawnRepeatedly());
		
	}

	private void OnDisable()
	{
		StopCoroutine(SpawnRepeatedly());
	}

	

	private IEnumerator SpawnRepeatedly()
	{
		while (true)
		{
			GameObject enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
			enemy.transform.parent = transform;
			enemy.GetComponent<SteeringBehaviors>().target = player;
			yield return new WaitForSeconds(spawnTime);
		}
	}

	
	
	
	
}
