using System;
using UnityEngine;
using strange.framework.api;

public class ResourceInstanceProvider : IInstanceProvider
{

	GameObject prototype;

	private string resourceName;

	private int layer;

	private int id = 0;



	public ResourceInstanceProvider(string name, int layer)
	{
		this.resourceName = name;
		this.layer = layer;
	}



	#region IInstanceProvider implementation

	public T GetInstance<T>()
	{
		object instance = GetInstance(typeof(T));
		T retv = (T)instance;
		return retv;
	}

	public object GetInstance(Type key)
	{
		if (prototype == null)
		{
			prototype = Resources.Load<GameObject>(resourceName);
			prototype.transform.localScale = Vector3.one;
		}

		GameObject go = GameObject.Instantiate(prototype) as GameObject;
		go.layer = layer;
		go.name = resourceName + "_" + id++;

		return go.GetComponent<PoolableView>();
	}

	public object GetInstance(Type key, Vector3 position, Quaternion rotation)
	{
		object go = GetInstance(key);
		(go as GameObject).transform.localPosition = position;
		(go as GameObject).transform.rotation = rotation;
		return go;
	}


	public object GetInstance(Type key, Vector3 position, Quaternion rotation, Transform parent)
	{
		object go = GetInstance(key, position, rotation);
		(go as GameObject).transform.parent = parent;
		return go;
	}

	#endregion
}
