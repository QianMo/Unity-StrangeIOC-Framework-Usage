//-------------------------------------------------------------------------------------
//	Singleton.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 单例类基类（抽象类、泛型，其他类只需继承此类即可成为单例类）
/// 继承该类的，相当于一个单例组件，如UIManager等
/// </summary>
public abstract class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T _instance = null;

    public static T Instance
    {
        get { return _instance; }
    }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}