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
    Transform parentTransform;

    private bool isCoroutineStarted = false;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
        parentTransform = GetComponentInParent<Transform>();
	}


	private void OnEnable()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void OnDisable()
	{
		StopCoroutine(SpawnRepeatedly());
	}

    private void Update()
    {
        if (hasImageBeenFound && !isCoroutineStarted)
        {
            isCoroutineStarted = true;
            StartCoroutine(SpawnRepeatedly());
        }
        else if(!hasImageBeenFound && isCoroutineStarted)
        {
            isCoroutineStarted = false;
            StopCoroutine(SpawnRepeatedly());
        }
    }


    private IEnumerator SpawnRepeatedly()
	{
		while (true)
		{
			GameObject enemy = Instantiate(EnemyPrefab, parentTransform.position, Quaternion.identity);
			enemy.transform.parent = transform;
			enemy.GetComponent<SteeringBehaviors>().target = player;
			yield return new WaitForSeconds(spawnTime);
		}
	}

	
	
	
	
}
