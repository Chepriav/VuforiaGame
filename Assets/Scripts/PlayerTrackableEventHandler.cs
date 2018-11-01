using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerTrackableEventHandler : DefaultTrackableEventHandler
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
		print("Player encontrado y spawner listo para ser encontrado");
	}


	protected override void OnTrackingLost()
	{
		base.OnTrackingLost();

        if(spawner != null)
		    spawner.SetActive(false);
        
		print("Player perdido,no se puede acceder al spawner");
		
	}

}
