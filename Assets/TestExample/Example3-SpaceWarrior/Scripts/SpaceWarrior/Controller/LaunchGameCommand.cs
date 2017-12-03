using UnityEngine;
using strange.extensions.command.impl;

public class LaunchGameCommand : Command
{

	[Inject]
	public ShowLevelPanelSignal showLevelPanelSignal{ get; set; }

	public override void Execute()
	{
		showLevelPanelSignal.Dispatch();
		// Maybe later we would like to do something here
	}
}
