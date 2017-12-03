using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class PlayerShipView : View
{
	public ScreenBoundary boundary;
	public GameObject HoldDown;

	public Signal FirstTimeTouchSignal;

	private bool isTouchDownFirstTime = false;
	private bool isTouched = false;
	private float defaultTimeScale;


	internal void Init()
	{
		FirstTimeTouchSignal = new Signal();

		defaultTimeScale = Time.timeScale = 1;
	}


	void Update()
	{
		if (isTouched)
		{
			Vector3 pos = transform.position;
			Vector3 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.x = inputPos.x;
			pos.y = inputPos.y;

			pos.x = Mathf.Clamp(pos.x, boundary.xMin, boundary.xMax); 
			pos.y = Mathf.Clamp(pos.y, boundary.yMin, boundary.yMax); 

			transform.position = pos;

			if (isTouchDownFirstTime)
			{
				FirstTimeTouchSignal.Dispatch();
			}
		}
	}


	void OnMouseDown()
	{
		isTouched = true;
		Time.timeScale = defaultTimeScale;

		if (!isTouchDownFirstTime) // Game has just started. Player touched for first time
		{
			isTouchDownFirstTime = true;
			HoldDown.SetActive(false);

		}
	}

	void OnMouseUp()
	{
		isTouched = false;
		Time.timeScale = 0.2f;
		// TODO: Add a pause UII
	}
}


