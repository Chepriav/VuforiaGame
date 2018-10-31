using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnerTrackableEventHandler : DefaultTrackableEventHandler
{
    public SpawnerBehaviour spawner;

	// Use this for initialization
	void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

    }


    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        spawner.hasImageBeenFound = true;
        print("Spawner encontrado");
    }


    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        spawner.hasImageBeenFound = false;
        print("Spawner Perdido");

    }
}
