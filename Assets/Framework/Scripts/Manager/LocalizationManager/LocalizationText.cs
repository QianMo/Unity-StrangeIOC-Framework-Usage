//-------------------------------------------------------------------------------------
//	LocalizationText.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationText : MonoBehaviour 
{
    public string key;

	void Start () 
	{
        string value = LocalizationManager.Instance.GetValue(key);
        if (GetComponent<Text>() != null)
        {
            GetComponent<Text>().text = value;
        }

	}
	
}
