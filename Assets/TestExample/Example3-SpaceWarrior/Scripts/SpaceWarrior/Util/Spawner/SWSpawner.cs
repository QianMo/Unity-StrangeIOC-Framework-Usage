using System;
using UnityEngine;
using System.Collections;


public class SWSpawner : ISpawner
{
	[Inject]
	public IRoutineRunner routineRunner{ get; set; }

	[Inject]
	public SWElement swElement { get; set; }

	[Inject]
	public AsteroidFactory asteroidFactory{ get; set; }

	[Inject]
	public EnemyFactory enemyFactory{ get; set; }

	[Inject]
	public LevelManagerScript levelManager { get; set; }

	[Inject]
	public ReturnInstanceSignal returnInstanceSignal { get; set; }




	[Inject]
	public ISWPool<AsteroidView> asteroidPool { get; set; }

	[Inject]
	public ISWPool<PlayerShipLaserView> playerLaserPool { get; set; }

	[Inject]
	public ISWPool<EnemyShipView> enemyShipPool { get; set; }


	private bool running = false;



	#region ISpawner implementation

	public void Start()
	{
		returnInstanceSignal.AddListener(OnReturnInstanceSignalDispatched);

		running = true;
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
			// Create Asteroid 
			if (asteroidFactory.LastSpawnTime >= levelManager.LevelInfo.Asteroid.SpawnTimeRate &&
			    asteroidFactory.CreatedObjectCount < levelManager.LevelInfo.Asteroid.MaxCount)
			{
				asteroidFactory.LastSpawnTime = 0;
				asteroidFactory.GetOpponent();
			}
			else
			{
				asteroidFactory.LastSpawnTime += Time.deltaTime;
			}


			// Create Enemy
			if (enemyFactory.LastSpawnTime >= levelManager.LevelInfo.Enemy.SpawnTimeRate &&
			    enemyFactory.CreatedObjectCount < levelManager.LevelInfo.Enemy.MaxCount)
			{
				enemyFactory.LastSpawnTime = 0;
				enemyFactory.GetOpponent();
			}
			else
			{
				enemyFactory.LastSpawnTime += Time.deltaTime;
			}

			yield return 0;
		}
	}


	void OnReturnInstanceSignalDispatched(PoolableView view)
	{

		TypeSwitch.Do(
			view,
			TypeSwitch.Case<PlayerShipLaserView>(x => playerLaserPool.ReturnInstance(x)),
			TypeSwitch.Case<AsteroidView>(x => asteroidPool.ReturnInstance(x)),
			TypeSwitch.Case<EnemyShipView>(x => enemyShipPool.ReturnInstance(x)),
			TypeSwitch.Default(() => {
				throw new NotSupportedException("This view can not supported!!!!!");
			})
		);


	}
}
