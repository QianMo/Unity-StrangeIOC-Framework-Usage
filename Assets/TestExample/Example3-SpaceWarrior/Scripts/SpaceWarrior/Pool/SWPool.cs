using System;
using strange.extensions.pool.impl;
using UnityEngine;
using strange.extensions.signal.impl;


public class SWPool<T> : Pool<T>, ISWPool<T> where T : PoolableView
{

	public new T GetInstance()
	{
		T go = base.GetInstance();
		return go;
	}

}

