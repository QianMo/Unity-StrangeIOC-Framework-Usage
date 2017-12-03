using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class HideLevelPanelCommandTest
{

	private HideLevelPanelCommand command;
	private SWElement swElement;

	[SetUp]
	public void SetUp()
	{
		command = new HideLevelPanelCommand();
		swElement = new SWElement();
		ShowLevelPanelCommand showLevelPanelCommand = new ShowLevelPanelCommand();
		showLevelPanelCommand.swElement = swElement;
		command.swElement = swElement;
		showLevelPanelCommand.Execute();
	}



	[Test]
	public void TestLevelPanelNotActive()
	{
		command.Execute();

		Assert.IsFalse(swElement.LevelPanel.gameObject.activeSelf);
	}

}

