using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using hamburgames.unity.spacewarriors;


public class HitByLaserCommandTest
{

	private HitByLaserCommand command;
	private int testHealth = 2;

	[SetUp]
	public void SetUp()
	{
		command = new HitByLaserCommand();
		command.health = testHealth;
		command.poolableView = GetAsteroid();
		command.playerShipLaserView = GetPlayerShipLaserView();
		command.playerLaserPool = new SWPool<PlayerShipLaserView>();
		command.playerLaserPool.instanceProvider = new ResourceInstanceProvider("Prefabs/player/PlayerShipLaser", LayerMask.NameToLayer("PlayerShipLaser")); 
		command.playerLaserHitPool = new SWPool<PlayerShipLaserHitView>();
		command.playerLaserHitPool.instanceProvider = new ResourceInstanceProvider("Prefabs/player/LaserGreenHit", LayerMask.NameToLayer("PlayerShipLaser")); 
		command.asteroidExplosionPool = new SWPool<AsteroidExplosionView>();
		command.asteroidExplosionPool.instanceProvider = new ResourceInstanceProvider("Explosions/Prefabs/AsteroidExplosion", LayerMask.NameToLayer("Asteroid")); 
		command.levelManager = new LevelManagerScript();
		command.routineRunner = GetRoutineRunner();
		command.scoreGainedSignal = new ScoreGainedSignal();
		command.returnInstanceSignal = new ReturnInstanceSignal();
	}

	[Test]
	public void TestReturnInstanceSignalDispatch()
	{
		bool signalReceived = false;
		command.returnInstanceSignal.AddListener((view) => {
			signalReceived = true;
		});
		command.Execute();
		Assert.IsTrue(signalReceived);
	}




	private PoolableView GetAsteroid()
	{
		ISWPool<AsteroidView> asteroidPool = new SWPool<AsteroidView>();
		asteroidPool.instanceProvider = new ResourceInstanceProvider("Prefabs/asteroid/Asteroid", LayerMask.NameToLayer("Asteroid"));
		return asteroidPool.GetInstance();
	}

	private PlayerShipLaserView GetPlayerShipLaserView()
	{
		ISWPool<PlayerShipLaserView> playerLaserPool = new SWPool<PlayerShipLaserView>();
		playerLaserPool.instanceProvider = new ResourceInstanceProvider("Prefabs/player/PlayerShipLaser", LayerMask.NameToLayer("PlayerShipLaser"));
		return playerLaserPool.GetInstance();
	}


	private RoutineRunner GetRoutineRunner()
	{
		RoutineRunner runner = new RoutineRunner();
		runner.contextView = new GameObject();
		runner.PostConstruct();
		return runner;
	}

}
