using System;
using UnityEngine;

public interface IScreenUtil
{
	bool IsInCamera(GameObject go);

	Vector3 BottomCenter { get; }
	Vector3 maxBound { get; }
}


