using UnityEngine;
using System.Collections;

public class UserModel
{
	[Inject]
	public ScoreUpdatedSignal scoreUpdatedSignal { get; set; }


	public int TotalScore{ get; private set; }
	public int TotalLive{ get; private set; }

	public void AddScore(int score)
	{
		// Maybe we send this score to a service instantly 
		TotalScore += score;
		scoreUpdatedSignal.Dispatch(TotalScore);
	}

	public void AddLive(int live)
	{
		TotalLive += live;
	}
}
