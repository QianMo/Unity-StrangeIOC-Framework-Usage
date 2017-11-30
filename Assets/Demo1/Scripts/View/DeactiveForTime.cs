//-------------------------------------------------------------------------------------
//	DeactiveForTime.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DeactiveForTime : MonoBehaviour
{
    void Start()
    {
        Invoke("Deactive", 3);
    }

    void Deactive()
    {
        this.gameObject.SetActive(false);
    }

}
