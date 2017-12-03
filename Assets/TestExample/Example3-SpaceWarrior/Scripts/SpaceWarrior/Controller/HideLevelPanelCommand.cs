using System;
using strange.extensions.command.impl;

public class HideLevelPanelCommand : Command
{
	[Inject]
	public SWElement swElement{ get; set;}
	
	public override void Execute()
	{
		swElement.LevelPanel.SetActive(false);
	}
}


