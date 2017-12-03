using UnityEngine;
using strange.extensions.mediation.impl;

public class UIViewMediator : Mediator
{
	[Inject]
	public UIView view { get; set; }


	[Inject]
	public ScoreUpdatedSignal scoreUpdatedSignal { get; set; }

	public override void OnRegister()
	{
		view.Init();
		scoreUpdatedSignal.AddListener(OnScoreUpdated);
	}

	private void OnScoreUpdated(int newScore)
	{
		view.score = newScore;
	}
}
