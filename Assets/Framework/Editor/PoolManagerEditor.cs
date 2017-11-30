//-------------------------------------------------------------------------------------
//	PoolManagerEditor.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEditor;

public class PoolManagerEditor
{

    [MenuItem("Manager/Create GameObjectPoolConfig")]
    static void CreateGameobjectPoolList()
    {
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();
        string path = "Assets/Framework/Resources/gameobjectpool.asset";
        AssetDatabase.CreateAsset(poolList, path);
        AssetDatabase.SaveAssets();

    }

}
