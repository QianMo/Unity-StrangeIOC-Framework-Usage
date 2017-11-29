using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class Demo1NextCommand : Command
{

    //-------------------------------------------------------------------
    /// 当这个命令被执行的时候，会默认调用Excute方法
    //-------------------------------------------------------------------
    public override void Execute()
    {
        Debug.Log("Enter Demo1NextCommand Execute！");
    }

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Enter Demo1NextCommand Start！");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
