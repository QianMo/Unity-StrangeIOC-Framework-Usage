using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;


public class OutOfScreenView : View
{
	public Signal<GameObject> OutOfViewportSignal;


	public bool wasInScreen;

	public void Init()
	{
		OutOfViewportSignal = new Signal<GameObject>();
	}

	void Update()
	{
		Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
		if (
			viewportPosition.x < 1 &&
			viewportPosition.x > 0 &&
			viewportPosition.y < 1 &&
			viewportPosition.y > 0
		)
		{
			wasInScreen = true;
		}


		if ( 
			viewportPosition.x > 1 ||
			viewportPosition.x < 0 ||
			viewportPosition.y > 1.05 ||
			viewportPosition.y < -0.05)
		{
			if (gameObject.activeSelf && wasInScreen)
			{
				OutOfViewportSignal.Dispatch(this.gameObject);
			}
		}
	}


}
