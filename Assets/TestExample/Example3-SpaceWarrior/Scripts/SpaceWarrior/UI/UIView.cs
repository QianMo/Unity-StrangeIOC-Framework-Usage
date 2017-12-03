using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;

public class UIView : View
{

	public Text scoreText;

	internal void Init()
	{
		//
	}

	public int score
	{
		set { scoreText.text = "Score: " + value; }
	}
}
