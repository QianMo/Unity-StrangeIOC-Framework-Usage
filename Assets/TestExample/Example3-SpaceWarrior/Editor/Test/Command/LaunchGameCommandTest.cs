using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class LaunchGameCommandTest
{
	private LaunchGameCommand command;

	[SetUp]
	public void SetUp()
	{
		command = new LaunchGameCommand();
		command.showLevelPanelSignal = new ShowLevelPanelSignal();
	}


	[Test]
	public void TestSignalDispatch()
	{
		bool signalReceived = false;
		command.showLevelPanelSignal.AddListener(() => {
			signalReceived = true;
		});
		command.Execute();
		Assert.IsTrue(signalReceived);
	}
}
