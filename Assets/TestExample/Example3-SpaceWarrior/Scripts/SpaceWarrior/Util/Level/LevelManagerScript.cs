using UnityEngine;
using strange.extensions.mediation.impl;
using System.Collections;

public class LevelManagerScript : View
{

	public int CurrentLevel = 1;

	[SerializeField]
	private Level[] levels;


	public Level LevelInfo
	{
		get { return levels[CurrentLevel - 1]; }
	}

}
