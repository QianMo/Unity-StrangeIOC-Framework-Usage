using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ShowLevelPanelCommandTest
{

	private ShowLevelPanelCommand command;
	 

	[SetUp]
	public void SetUp()
	{
		command = new ShowLevelPanelCommand();
		command.swElement = new SWElement();
		command.Execute();
	}

	[Test]
	public void TestUICanvasShouldFound()
	{
		Assert.IsNotNull(command.ui);
	}

	[Test]
	public void TestLevelPanelSettedProperly()
	{
		Assert.IsNotNull(command.swElement.LevelPanel);
	}

}
