using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.pool.api;
using strange.extensions.pool.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class SpaceWarriorContext : MVCSContext
{
	public SpaceWarriorContext(MonoBehaviour contextView) : base(contextView) { }


	public override void Launch()
	{
		base.Launch();

		GameUpAndReadySignal gameUpAndReadySignal = (GameUpAndReadySignal)injectionBinder.GetInstance<GameUpAndReadySignal>();
		gameUpAndReadySignal.Dispatch();
	}

	protected override void addCoreComponents()
	{
		base.addCoreComponents();

		injectionBinder.Unbind<ICommandBinder>();
		injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
	}

	protected override void mapBindings()
	{
		base.mapBindings();

		implicitBinder.ScanForAnnotatedClasses(new string[]{ "hamburgames.unity.spacewarriors" });

		var levelManager = GameObject.Find("LevelManager").GetComponent<LevelManagerScript>();
		injectionBinder.Bind<LevelManagerScript>().ToValue(levelManager);

		injectionBinder.Bind<SWElement>().ToSingleton();
		injectionBinder.Bind<UserModel>().ToSingleton();
		injectionBinder.Bind<PlayerShipModel>().ToSingleton();
		injectionBinder.Bind<AsteroidFactory>().ToSingleton();
		injectionBinder.Bind<EnemyFactory>().ToSingleton();

		// Spawners
		injectionBinder.Bind<ISpawner>().To<PlayerLaserSpawner>().ToSingleton().ToName(SpaceWarriorSpawner.PLAYER_LASER_SPAWNER);
		injectionBinder.Bind<ISpawner>().To<SWSpawner>().ToSingleton().ToName(SpaceWarriorSpawner.MAIN_SPAWNER);

		mediationBinder.Bind<UIView>().To<UIViewMediator>();
		mediationBinder.Bind<LevelView>().To<LevelViewMediator>();
		mediationBinder.Bind<OutOfScreenView>().To<OutOfScreenMediator>();
		mediationBinder.Bind<PlayerShipView>().To<PlayerShipMediator>(); 
		mediationBinder.Bind<PlayerShipLaserView>().To<PlayerShipLaserMediator>();
		mediationBinder.Bind<AsteroidView>().To<AsteroidViewMediator>();
		mediationBinder.Bind<EnemyShipView>().To<EnemyShipViewMediator>();


		commandBinder.Bind<GameUpAndReadySignal>().To<LaunchGameCommand>().Once();
		commandBinder.Bind<ShowLevelPanelSignal>().To<ShowLevelPanelCommand>();
		commandBinder.Bind<HideLevelPanelSignal>().To<HideLevelPanelCommand>();
		commandBinder.Bind<StartLevelSignal>().To<StartLevelCommand>();
		commandBinder.Bind<SpawnPlayerShipSignal>().To<SpawnPlayerShipCommand>();
		commandBinder.Bind<HitByLaserSignal>().To<HitByLaserCommand>();
		commandBinder.Bind<ScoreGainedSignal>().To<ScoreGainedCommand>();


		// Independent Signals
		injectionBinder.Bind<ScoreUpdatedSignal>().ToSingleton();
		injectionBinder.Bind<ReturnInstanceSignal>().ToSingleton();


		// Pools
		injectionBinder.Bind<ISWPool<PlayerShipLaserView>>().To<SWPool<PlayerShipLaserView>>().ToSingleton();
		injectionBinder.Bind<ISWPool<PlayerShipLaserHitView>>().To<SWPool<PlayerShipLaserHitView>>().ToSingleton();
		injectionBinder.Bind<ISWPool<AsteroidView>>().To<SWPool<AsteroidView>>().ToSingleton();
		injectionBinder.Bind<ISWPool<EnemyShipView>>().To<SWPool<EnemyShipView>>().ToSingleton();
		injectionBinder.Bind<ISWPool<AsteroidExplosionView>>().To<SWPool<AsteroidExplosionView>>().ToSingleton();
		injectionBinder.Bind<ISWPool<GainedScoreView>>().To<SWPool<GainedScoreView>>().ToSingleton();
	}

	protected override void postBindings()
	{
		ISWPool<PlayerShipLaserView> playerLaserPool = injectionBinder.GetInstance<ISWPool<PlayerShipLaserView>>();
		playerLaserPool.instanceProvider = new ResourceInstanceProvider("Prefabs/player/PlayerShipLaser", LayerMask.NameToLayer("PlayerShipLaser"));
		playerLaserPool.inflationType = PoolInflationType.INCREMENT;

		ISWPool<PlayerShipLaserHitView> playerLaserHitPool = injectionBinder.GetInstance<ISWPool<PlayerShipLaserHitView>>();
		playerLaserHitPool.instanceProvider = new ResourceInstanceProvider("Prefabs/player/LaserGreenHit", LayerMask.NameToLayer("PlayerShipLaser"));
		playerLaserHitPool.inflationType = PoolInflationType.INCREMENT;


		ISWPool<AsteroidView> asteroidPool = injectionBinder.GetInstance<ISWPool<AsteroidView>>();
		asteroidPool.instanceProvider = new ResourceInstanceProvider("Prefabs/asteroid/Asteroid", LayerMask.NameToLayer("Asteroid"));
		asteroidPool.inflationType = PoolInflationType.INCREMENT;


		ISWPool<EnemyShipView> enemyPool = injectionBinder.GetInstance<ISWPool<EnemyShipView>>();
		enemyPool.instanceProvider = new ResourceInstanceProvider("Prefabs/enemy/EnemyRed", LayerMask.NameToLayer("Enemy"));
		enemyPool.inflationType = PoolInflationType.INCREMENT;


		ISWPool<AsteroidExplosionView> asteroidExplosionPool = injectionBinder.GetInstance<ISWPool<AsteroidExplosionView>>();
		asteroidExplosionPool.instanceProvider = new ResourceInstanceProvider("Explosions/Prefabs/AsteroidExplosion", LayerMask.NameToLayer("Asteroid"));
		asteroidExplosionPool.inflationType = PoolInflationType.INCREMENT;


		ISWPool<GainedScoreView> gainedScorePool = injectionBinder.GetInstance<ISWPool<GainedScoreView>>();
		gainedScorePool.instanceProvider = new ResourceInstanceProvider("Prefabs/score/GainedScore", LayerMask.NameToLayer("Default"));
		gainedScorePool.inflationType = PoolInflationType.INCREMENT;


		base.postBindings();
	}

}

