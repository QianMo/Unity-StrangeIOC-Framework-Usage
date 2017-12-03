using System;
using UnityEngine;




public class ScreenBoundary
{
	public float xMin, xMax, yMin, yMax;

	public ScreenBoundary(float xMin, float yMin, float xMax, float yMax)
	{
		this.xMin = xMin;
		this.yMin = yMin;
		this.xMax = xMax;
		this.yMax = yMax;
	}
}


public class PlayerShipModel
{

	[Inject]
	public IScreenUtil screenUtil { get; set; }

	public float Speed;
	public float FireRate;
	public Transform ShotSpawn;
	public Vector3 SpawnPosition;
	public Quaternion SpawnRotation;
	public ScreenBoundary Boundary;


	[PostConstruct]
	public void PostConstruct()
	{
		Vector3 bottomCenter = screenUtil.BottomCenter;
		Vector3 bottomOffset = new Vector3(0f, -1f, 0f);
		Boundary = new ScreenBoundary(
			-screenUtil.maxBound.x + 0.5f,
			-screenUtil.maxBound.y + 0.5f,
			screenUtil.maxBound.x - 0.5f,
			screenUtil.maxBound.y - 0.5f
		);
		SpawnPosition = bottomCenter - bottomOffset;
		SpawnRotation = Quaternion.identity;
		FireRate = 0.5f;
		Speed = 6;

	}

}




