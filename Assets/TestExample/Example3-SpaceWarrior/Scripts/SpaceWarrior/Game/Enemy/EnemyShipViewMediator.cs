using UnityEngine;
using strange.extensions.mediation.impl;

public class EnemyShipViewMediator : Mediator
{
	[Inject]
	public EnemyShipView view { get; set; }


	[Inject]
	public HitByLaserSignal hitByLaserSigal { get; set; }


	public override void OnRegister()
	{
		view.LaserHitSignal.AddListener(OnHitByLaser);
	}

	private void OnHitByLaser(EnemyShipView enemyShipView, PlayerShipLaserView playerShipLaserView, int health)
	{
		hitByLaserSigal.Dispatch(enemyShipView, playerShipLaserView, health);
	}
}
