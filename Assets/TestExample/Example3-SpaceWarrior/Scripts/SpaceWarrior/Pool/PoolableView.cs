using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.pool.api;

public class PoolableView : View, IPoolable
{


	public void Reinit(Vector3 position, Quaternion rotation, Transform parent)
	{
		transform.position = position;
		transform.rotation = rotation;
		transform.parent = parent;
		gameObject.SetActive(true);
	}



	#region IPoolable implementation

	private bool _retain = false;

	public void Restore()
	{
		gameObject.SetActive(false);
		transform.position = SWElement.PARKED_POS;
	}

	public void Retain()
	{
		_retain = true;
	}

	public void Release()
	{
		_retain = false;

	}

	public bool retain
	{
		get { return _retain; }
	}

	#endregion
}
