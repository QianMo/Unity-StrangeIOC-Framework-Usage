using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class LevelViewMediator : Mediator
{
	[Inject]
	public LevelView view { get; set; }

	[Inject]
	public StartLevelSignal startLevelSignal{ get; set; }


	public override void OnRegister()
	{
		base.OnRegister();

		view.Init();

		view.StartButtonSignal.AddListener(OnStartButtonSignalDispatched);
	}


	private void OnStartButtonSignalDispatched()
	{
		// TODO: Level Info should come from somewhere. LevelModel maybe?
		startLevelSignal.Dispatch(1);
	}
}
