using System;

public interface IOpponentModel
{
	int Health { get; set; }
	int Score{ get; set; }
	float MinSpeed{ get; set; }
	float MaxSpeed{ get; set; }
	float SpawnTimeRate{ get; set; }
	int MaxCount{ get; set; }
	bool HasRigidBody { get; set; }
}
