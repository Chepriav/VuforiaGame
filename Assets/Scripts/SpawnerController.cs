using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnerController : DefaultTrackableEventHandler
{

	public GameObject spawner;
	
	// Use this for initialization
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		
		if(mTrackableBehaviour)
			mTrackableBehaviour.RegisterTrackableEventHandler(this);

	}
	
	protected override void OnTrackingFound()
	{		
		base.OnTrackingFound();
		spawner.SetActive(true);
		print("Encontrado");
	}


	protected override void OnTrackingLost()
	{
		base.OnTrackingLost();
		spawner.SetActive(false);
		print("parado");
		
	}

}
