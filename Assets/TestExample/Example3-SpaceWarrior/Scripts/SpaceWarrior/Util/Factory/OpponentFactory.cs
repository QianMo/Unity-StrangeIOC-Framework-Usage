using System;
using UnityEngine;

public class OpponentFactory : AbstractOpponentFactory
{
	[Inject]
	public LevelManagerScript levelManager { get; set; }

	[Inject]
	public IScreenUtil screenUtil { get; set; }



	private float _lastSpawnTime = 0;
	private int _createdObjectCount = 0;



	#region implemented abstract members of AbstractOpponentFactory


	protected override void AddOutOfScreenComponent(PoolableView go)
	{
		if (go.GetComponent<OutOfScreenView>() == null)
			go.gameObject.AddComponent<OutOfScreenView>();
		go.GetComponent<OutOfScreenView>().wasInScreen = false;
	}


	protected override Vector3 RandomPosition()
	{
		float randomX = UnityEngine.Random.Range(-screenUtil.maxBound.x + 0.5f, screenUtil.maxBound.x - 0.5f);
		float randomY = UnityEngine.Random.Range(screenUtil.maxBound.y, screenUtil.maxBound.y + 1f);

		return new Vector3(randomX, randomY, 10f);
	}


	public override PoolableView GetOpponent()
	{
		throw new NotImplementedException("Override this function!!!");
	}


	public override float LastSpawnTime
	{
		get { return _lastSpawnTime; }
		set { _lastSpawnTime = value; }
	}


	public override int CreatedObjectCount
	{
		get { return _createdObjectCount; }
		set { _createdObjectCount = value; }
	}

	#endregion



}
