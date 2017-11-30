//-------------------------------------------------------------------------------------
//	PoolManager.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager
{

	public static PoolManager _instance;
	public static PoolManager Instance
	{
		get
		{
			if(_instance==null)
			{
				_instance = new PoolManager();
			}
			return _instance;
		}
	}

    //resource路径下的资源，用Resources.Load，不用加后缀，只用和resource路径的相对路径。
    public static string PoolConfigPath = "gameobjectpool";

    private Dictionary<string, GameObjectPool> poolMap= new Dictionary<string, GameObjectPool>();


    private PoolManager()
    {
     
    }

    public void Init()
	{
        GameObjectPoolList poolList = Resources.Load<GameObjectPoolList>(PoolConfigPath);

        //初始化poolMap
        if (poolMap == null)
        {
            poolMap = new Dictionary<string, GameObjectPool>();
        }
        poolMap.Clear();
        foreach (GameObjectPool pool in poolList.poolList)
        {
            if (poolMap.ContainsKey(pool.name))
            {
                continue;
            }
            poolMap.Add(pool.name, pool);
        }

        //
    }

    public GameObject GePoolObjByName(string poolName)
    {
        GameObjectPool pool;
        if (poolMap.TryGetValue(poolName, out pool))
        {
            return pool.GetInst();
        }

        Debug.LogWarning("pool name  " + poolName + "dont find!!");
        return null;
    }



}
