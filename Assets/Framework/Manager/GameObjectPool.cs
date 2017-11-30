//-------------------------------------------------------------------------------------
//	GameObjectPool.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class GameObjectPool
{
    //名称
    [SerializeField]
    public string name;
    //prefab
    [SerializeField]
    public GameObject prefab;
    //最大数量
    [SerializeField]
    public int maxAmount;
    
    [NonSerialized]
    private List<GameObject> goList = new List<GameObject>();



    /// <summary>
    /// 表示从资源池中获取一个实例
    /// </summary>
    public GameObject GetInst()
    {
        foreach (GameObject go in goList)
        {
            if (go.activeInHierarchy == false)
            {
                return go;
            }
        }


        if (goList.Count>= maxAmount)
        {
            //
            GameObject.Destroy(goList[0]);
            goList.RemoveAt(0);
        }

        GameObject temp=GameObject.Instantiate(prefab) as GameObject;
        goList.Add(temp);
        return temp;
    }

}
