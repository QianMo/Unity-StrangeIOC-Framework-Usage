using System;
using UnityEngine;


public abstract class AbstractOpponentFactory
{
	protected abstract void AddOutOfScreenComponent(PoolableView go);
	protected abstract Vector3 RandomPosition();

	public abstract PoolableView GetOpponent();
	public abstract float LastSpawnTime{ get; set; }
	public abstract int CreatedObjectCount{ get; set; }
}
