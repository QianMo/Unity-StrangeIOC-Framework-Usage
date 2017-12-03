using System;
using UnityEngine;
using strange.extensions.command.impl;

public class SpawnPlayerShipCommand : Command
{
	[Inject]
	public SWElement swElement{ get; set; }

	[Inject]
	public PlayerShipModel playerShipModel{ get; set; }

	public override void Execute()
	{
		// FIXME: Find a better solution to instantiate ship
		// it should be in a controller class. or from a clas that has a ISpawner interface

		if (swElement.Warrior == null)
		{
			swElement.Warrior = GameObject.Instantiate(
				Resources.Load("Prefabs/player/PlayerShip") as GameObject,
				playerShipModel.SpawnPosition,
				playerShipModel.SpawnRotation
			) as GameObject;
		}
		else
		{
			swElement.Warrior.transform.position = playerShipModel.SpawnPosition;
			swElement.Warrior.transform.rotation = playerShipModel.SpawnRotation;
			swElement.Warrior.SetActive(true);
		}

		swElement.Warrior.GetComponent<PlayerShipView>().boundary = playerShipModel.Boundary;

		playerShipModel.ShotSpawn = swElement.Warrior.transform.Find("ShotSpawn");
	}
}
