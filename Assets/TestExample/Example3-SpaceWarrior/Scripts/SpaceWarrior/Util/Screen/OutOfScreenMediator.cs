using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.injector.api;

public class OutOfScreenMediator : Mediator
{
	[Inject]
	public OutOfScreenView view { get; set; }

	[Inject]
	public ReturnInstanceSignal returnInstanceSignal { get; set; }



	public override void OnRegister()
	{
		view.Init();

		view.OutOfViewportSignal.AddListener(RecycleLaser);
	}


	private void RecycleLaser(GameObject theGameObject)
	{
		returnInstanceSignal.Dispatch(theGameObject.GetComponent<PoolableView>());
	}
}

