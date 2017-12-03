using UnityEngine;
using strange.extensions.mediation.impl;

public class AsteroidViewMediator: Mediator
{

	[Inject]
	public AsteroidView view { get; set; }

	[Inject]
	public HitByLaserSignal asteroidHitByLaserSignal { get; set; }

	public override void OnRegister()
	{
		view.Init();

		view.LaserHitSignal.AddListener(OnHitByLaser);
	}

	private void OnHitByLaser(AsteroidView asteroidView, PlayerShipLaserView playerShipLaserView, int health)
	{
		asteroidHitByLaserSignal.Dispatch(asteroidView, playerShipLaserView, health);
	}
}
