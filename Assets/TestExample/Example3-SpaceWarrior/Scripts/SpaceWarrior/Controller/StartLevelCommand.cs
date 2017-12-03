using System;
using strange.extensions.command.impl;

public class StartLevelCommand : Command
{
	[Inject]
	public SpawnPlayerShipSignal spawnPlayerShipSignal { get; set; }

	[Inject]
	public HideLevelPanelSignal hideLevelPanelSignal{ get; set; }

	public override void Execute()
	{
		hideLevelPanelSignal.Dispatch();

		spawnPlayerShipSignal.Dispatch();
	}
}


