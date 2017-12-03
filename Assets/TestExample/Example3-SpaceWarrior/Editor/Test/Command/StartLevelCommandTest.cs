using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class StartLevelCommandTest
{

	private StartLevelCommand command;

	[SetUp]
	public void SetUp()
	{
		command = new StartLevelCommand();
		command.hideLevelPanelSignal = new HideLevelPanelSignal();
		command.spawnPlayerShipSignal = new SpawnPlayerShipSignal();
	}
	
	[Test]
	public void TestHideLevelPanelSignalDispatch()
	{
		bool signalReceived = false;
		command.hideLevelPanelSignal.AddListener(() => {
			signalReceived = true;
		});
		command.Execute();
		Assert.IsTrue(signalReceived);
	}

	[Test]
	public void TestSpawnPlayerShipSignalDispatch()
	{
		bool signalReceived = false;
		command.hideLevelPanelSignal.AddListener(() => {
			signalReceived = true;
		});
		command.Execute();
		Assert.IsTrue(signalReceived);
	}
}
