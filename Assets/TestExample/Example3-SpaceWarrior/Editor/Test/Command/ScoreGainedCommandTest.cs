using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using hamburgames.unity.spacewarriors;


public class ScoreGainedCommandTest
{

	private ScoreGainedCommand command;

	private int testGainedScore = 20;
	private Vector3 testPosition = Vector3.one;

	[SetUp]
	public void SetUp()
	{
		command = new ScoreGainedCommand();
		command.gainedScore = testGainedScore;
		command.position = testPosition;
		command.userModel = new UserModel();
		command.userModel.scoreUpdatedSignal = new ScoreUpdatedSignal();
		command.gainedScorePool = new SWPool<GainedScoreView>();
		command.gainedScorePool.instanceProvider = new ResourceInstanceProvider("Prefabs/score/GainedScore", LayerMask.NameToLayer("Default")); 
		command.routineRunner = GetRoutineRunner();

	}

	[Test]
	public void TestUserScore()
	{
		command.Execute();
		Assert.AreEqual(testGainedScore, command.userModel.TotalScore);
	}


	[TearDown]
	public void TearDown()
	{
		string scoreParentTag = StringEnum.GetStringValue(SpaceWarriorTag.GainedScoresParent);


		foreach (Transform child in GameObject.FindGameObjectWithTag(scoreParentTag).transform) {
			GameObject.DestroyImmediate(child.gameObject);
		}

	}

	private RoutineRunner GetRoutineRunner()
	{
		RoutineRunner runner = new RoutineRunner();
		runner.contextView = new GameObject();
		runner.PostConstruct();
		return runner;
	}

}
