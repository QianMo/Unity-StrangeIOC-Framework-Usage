using System;
using strange.extensions.mediation.impl;

public class PlayerShipMediator : Mediator
{

	[Inject]
	public PlayerShipView view { get; set; }

	[Inject(SpaceWarriorSpawner.PLAYER_LASER_SPAWNER)]
	public ISpawner playerLaserSpawner { get; set; }

	[Inject(SpaceWarriorSpawner.MAIN_SPAWNER)]
	public ISpawner swSpawner { get; set; }

	public override void OnRegister()
	{
		base.OnRegister();

		view.Init();

		view.FirstTimeTouchSignal.AddOnce(OnTouchFirstTime);
	}

	void OnTouchFirstTime()
	{
		playerLaserSpawner.Start();
		swSpawner.Start();
	}
}

