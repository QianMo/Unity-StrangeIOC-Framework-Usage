using System;
using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class HitByLaserCommand : Command
{
	#region SIGNAL PARAMETERS

	[Inject]
	public int health { get; set; }

	[Inject]
	public PoolableView poolableView { get; set; }

	[Inject]
	public PlayerShipLaserView playerShipLaserView { get; set; }

	#endregion



	#region POOLS

	[Inject]
	public ISWPool<PlayerShipLaserView> playerLaserPool { get; set; }

	[Inject]
	public ISWPool<PlayerShipLaserHitView> playerLaserHitPool { get; set; }

	[Inject]
	public ISWPool<AsteroidExplosionView> asteroidExplosionPool { get; set; }

	#endregion



	[Inject]
	public LevelManagerScript levelManager { get; set; }

	[Inject]
	public IRoutineRunner routineRunner { get; set; }

	[Inject]
	public ScoreGainedSignal scoreGainedSignal { get; set; }

	[Inject]
	public ReturnInstanceSignal returnInstanceSignal { get; set; }




	private bool isDestroymentFinish = false;
	private float laserHitAliveDuration = 0.03f;
	private float explosionAnimationDuration;
	private PlayerShipLaserHitView playerLaserHit;
	private AsteroidExplosionView explosion;


	public override void Execute()
	{
		Retain();

		playerLaserHit = playerLaserHitPool.GetInstance();
		playerLaserHit.Reinit(
			poolableView.transform.position,
			poolableView.transform.rotation,
			playerShipLaserView.transform.parent
		);


		if (health <= 0)
		{
			// It is only for asteroid
			scoreGainedSignal.Dispatch(levelManager.LevelInfo.Asteroid.Score, poolableView.transform.position);

			explosion = asteroidExplosionPool.GetInstance();
			explosion.Reinit(
				poolableView.transform.position,
				poolableView.transform.rotation,
				poolableView.transform.parent
			);

			explosionAnimationDuration = explosion.GetComponent<ParticleSystem>().duration;
			explosion.GetComponent<AudioSource>().Play();
		}

		routineRunner.StartCoroutine(destroyCoroutine());
	}


	IEnumerator destroyCoroutine()
	{
		while (!isDestroymentFinish)
		{
			returnInstanceSignal.Dispatch(playerShipLaserView);

			if (health <= 0)
			{
				returnInstanceSignal.Dispatch(poolableView);
			}

			yield return new WaitForSeconds(laserHitAliveDuration);
			playerLaserHit.Restore();
			playerLaserHitPool.ReturnInstance(playerLaserHit);

			if (explosionAnimationDuration > 0)
			{
				yield return new WaitForSeconds(explosionAnimationDuration - 0.5f);
				explosion.Restore();
				asteroidExplosionPool.ReturnInstance(explosion);
			}
			isDestroymentFinish = true;
		}

		Release();
	}


}
