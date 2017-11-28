using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class Demo1StartCommand : Command
{

    //-------------------------------------------------------------------
    /// 当这个命令被执行的时候，会默认调用Excute方法
    //-------------------------------------------------------------------
    public override void Execute()
    {
        Debug.Log("Enter Demo1StartCommand Execute！");
    }

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Enter Demo1StartCommand Start！");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
