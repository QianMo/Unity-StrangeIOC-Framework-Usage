using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class LevelView : View
{
	public Signal StartButtonSignal = new Signal{ };

	internal void Init()
	{
		//
	}

	public void OnClickStartButton()
	{
		StartButtonSignal.Dispatch();
	}
}
