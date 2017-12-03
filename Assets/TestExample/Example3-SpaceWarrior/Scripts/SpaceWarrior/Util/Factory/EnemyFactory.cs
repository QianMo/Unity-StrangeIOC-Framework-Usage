using System;
using UnityEngine;

public class EnemyFactory : OpponentFactory
{
	[Inject]
	public ISWPool<EnemyShipView> enemyPool { get; set; }

	public override PoolableView GetOpponent()
	{
		Vector3 randomPos = RandomPosition();
		string enemyParentTag = StringEnum.GetStringValue(SpaceWarriorTag.EnemysParent);

		EnemyShipView enemy = enemyPool.GetInstance();
		AddOutOfScreenComponent(enemy);
		enemy.Reinit(
			randomPos,
			Quaternion.identity,
			GameObject.FindGameObjectWithTag(enemyParentTag).transform
		);
		enemy.Init(
			levelManager.LevelInfo.Enemy.Health,
			levelManager.LevelInfo.Enemy.MinSpeed,
			levelManager.LevelInfo.Enemy.MaxSpeed
		);
		CreatedObjectCount++;

		return enemy;
	}

}
