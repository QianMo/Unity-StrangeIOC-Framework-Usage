using System;


[Serializable]
public class OpponentModel
{
	public int Health;
	public int Score;
	public float MinSpeed;
	public float MaxSpeed;
	public float SpawnTimeRate;
	public int MaxCount;


	public OpponentModel(int health, int score, float minSpeed, float maxSpeed, float spawnTimeRate, int maxCount)
	{
		Health = health;
		Score = score;
		MinSpeed = minSpeed;
		MaxSpeed = maxSpeed;
		SpawnTimeRate = spawnTimeRate;
		MaxCount = maxCount;
	}

	//	public int Health
	//	{
	//		get { return _health; }
	//		set { _health = value; }
	//	}
	//	public int Score
	//	{
	//		get { return _score; }
	//		set { _score = value; }
	//	}
	//	public float MinSpeed
	//	{
	//		get { return _minSpeed; }
	//		set { _minSpeed = value; }
	//	}
	//	public float MaxSpeed
	//	{
	//		get { return _maxSpeed; }
	//		set { _maxSpeed = value; }
	//	}
	//	public float SpawnTimeRate
	//	{
	//		get { return _spawnTimeRate; }
	//		set { _spawnTimeRate = value; }
	//	}
	//	public int MaxCount
	//	{
	//		get { return _maxCount; }
	//		set { _maxCount = value; }
	//	}
	//	public bool HasRigidBody
	//	{
	//		get { return _hasRigidBody; }
	//		set { _hasRigidBody = value; }
	//	}
}


