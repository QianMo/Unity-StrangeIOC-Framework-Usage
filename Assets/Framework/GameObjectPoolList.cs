//-------------------------------------------------------------------------------------
//	GameObjectPoolList.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//继承自ScriptableObject表示，此类是可以自定义资源配置的文件
public class GameObjectPoolList : ScriptableObject
{
    public List<GameObjectPool> poolList;

}
