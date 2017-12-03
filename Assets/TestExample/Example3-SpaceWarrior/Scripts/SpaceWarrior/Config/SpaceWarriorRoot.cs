using UnityEngine;
using strange.extensions.context.impl;


public class SpaceWarriorRoot : ContextView
{

	void Start()
	{
		context = new SpaceWarriorContext(this);
	}

}
