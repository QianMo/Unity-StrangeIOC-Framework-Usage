using System;
using UnityEngine;


public class AsteroidFactory : OpponentFactory
{

	[Inject]
	public ISWPool<AsteroidView> asteroidPool { get; set; }


	public override PoolableView GetOpponent()
	{
		Vector3 randomPos = RandomPosition();
		string asteroidParentTag = StringEnum.GetStringValue(SpaceWarriorTag.AsteroidsParent);

		AsteroidView asteroid = asteroidPool.GetInstance();
		AddOutOfScreenComponent(asteroid);
		asteroid.Reinit(
			randomPos,
			Quaternion.identity,
			GameObject.FindGameObjectWithTag(asteroidParentTag).transform
		);
		asteroid.Init(
			levelManager.LevelInfo.Asteroid.Health,
			levelManager.LevelInfo.Asteroid.MinSpeed,
			levelManager.LevelInfo.Asteroid.MaxSpeed
		);
		CreatedObjectCount++;

		return asteroid;
	}

}
