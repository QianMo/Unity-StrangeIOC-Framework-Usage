using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.injector.api;


public class PlayerShipLaserMediator : Mediator
{
	[Inject]
	public PlayerShipLaserView view { get; set; }


	public override void OnRegister()
	{
		view.Init();
	}

}


