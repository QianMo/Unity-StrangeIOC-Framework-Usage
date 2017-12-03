using UnityEngine;
using strange.extensions.command.impl;

public class ShowLevelPanelCommand : Command
{
	[Inject]
	public SWElement swElement{ get; set; }


	public GameObject ui;


	public override void Execute()
	{
		ui = GameObject.FindGameObjectWithTag("UI") as GameObject;

		if (ui == null)
		{
			Debug.LogError("UI did not find. Please create a canvas and give it 'UI' tag.");
			return;
		}

		var currentLevelView = ui.transform.Find("LevelPanel");

		if (currentLevelView == null)
		{
			GameObject levelPanel = GameObject.Instantiate(Resources.Load("Prefabs/UI/LevelPanel") as GameObject);
			levelPanel.name = "LevelPanel";
			levelPanel.transform.SetParent(ui.GetComponent<Canvas>().transform, false);
			swElement.LevelPanel = levelPanel;
		}
		else
		{
			currentLevelView.gameObject.SetActive(true);
			swElement.LevelPanel = currentLevelView.gameObject;
		}

	}
}
