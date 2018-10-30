using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnerBehaviour : MonoBehaviour
{

	public GameObject EnemyPrefab;
	public Transform player;
	public float spawnTime = 5.0f;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void OnEnable()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
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
			enemy.transform.parent = player.transform;
			enemy.GetComponent<SteeringBehaviors>().target = player;
			yield return new WaitForSeconds(spawnTime);
		}
	}

	
	
	
	
}
