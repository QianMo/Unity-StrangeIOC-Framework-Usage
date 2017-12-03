using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.pool.api;

public class PlayerShipLaserView : PoolableView
{

	public void Init()
	{
		//
	}

	void Update()
	{
		Vector3 pos = transform.position;
		pos.y += Time.deltaTime * 5;
		transform.position = pos;
	}

}
