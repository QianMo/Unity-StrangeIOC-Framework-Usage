using System;
using UnityEngine;
using System.Collections;
using strange.extensions.pool.api;
using strange.extensions.signal.impl;
using strange.extensions.signal.api;

public class PlayerLaserSpawner : ISpawner
{
	[Inject]
	public IRoutineRunner routineRunner{ get; set; }

	[Inject]
	public PlayerShipModel playerShipModel { get; set; }

	[Inject]
	public SWElement swElement { get; set; }

	[Inject]
	public ISWPool<PlayerShipLaserView> playerLaserPool{ get; set; }



	private bool running = false;
	string laserParentTag;
	Transform laserParent;



	#region ISpawner implementation

	public void Start()
	{
		running = true;
		laserParentTag = StringEnum.GetStringValue(SpaceWarriorTag.PlayerLasersParent);
		laserParent = GameObject.FindGameObjectWithTag(laserParentTag).transform;
		routineRunner.StartCoroutine(spawn());
	}

	public void Stop()
	{
		running = false;
	}

	#endregion



	IEnumerator spawn()
	{
		while (running)
		{
			
			PlayerShipLaserView playerShipLaser = playerLaserPool.GetInstance();
		
			playerShipLaser.Reinit(
				playerShipModel.ShotSpawn.position,
				Quaternion.identity,
				laserParent
			);

			playerShipLaser.gameObject.AddComponent<OutOfScreenView>();

			swElement.Warrior.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(playerShipModel.FireRate);
		}
	}
}
