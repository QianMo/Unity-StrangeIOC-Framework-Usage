using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class SpawnPlayerShipCommandTest
{

	private SpawnPlayerShipCommand command;

	[SetUp]
	public void SetUp()
	{
		command = new SpawnPlayerShipCommand();
		command.swElement = new SWElement();
		command.playerShipModel = new PlayerShipModel();
		command.Execute();
	}


	[Test]
	public void TestPlayerShipAlive()
	{
		Assert.IsNotNull(command.swElement.Warrior);
	}


	[Test]
	public void TestShotSpawnSetOnModel()
	{
		Assert.IsNotNull(command.playerShipModel.ShotSpawn);
	}


}
