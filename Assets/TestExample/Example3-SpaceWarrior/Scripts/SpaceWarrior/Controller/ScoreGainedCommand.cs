using System;
using System.Collections;
using UnityEngine;
using strange.extensions.command.impl;

public class ScoreGainedCommand : Command
{
	[Inject]
	public int gainedScore { get; set; }

	[Inject]
	public Vector3 position { get; set; }

	[Inject]
	public UserModel userModel { get; set; }

	[Inject]
	public ISWPool<GainedScoreView> gainedScorePool { get; set; }

	[Inject]
	public IRoutineRunner routineRunner { get; set; }


	private GainedScoreView scoreGo;

	public override void Execute()
	{
		Retain();

		userModel.AddScore(gainedScore);

		string scoreParentTag = StringEnum.GetStringValue(SpaceWarriorTag.GainedScoresParent);

		scoreGo = gainedScorePool.GetInstance();
		scoreGo.Reinit(
			position,
			Quaternion.identity,
			GameObject.FindGameObjectWithTag(scoreParentTag).transform
		);

		scoreGo.GetComponent<TextMesh>().text = "+" + gainedScore;

		routineRunner.StartCoroutine(DestroyScore());
	}



	IEnumerator DestroyScore()
	{
		yield return new WaitForSeconds(0.2f);
		scoreGo.Restore();
		gainedScorePool.ReturnInstance(scoreGo);

		Release();
	}
}


