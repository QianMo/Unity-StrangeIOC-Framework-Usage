using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class Demo1StartCommand : Command
{
    [Inject]
    public AudioManager AudioManagerInstance { get; set; }

    //-------------------------------------------------------------------
    /// 当这个命令被执行的时候，会默认调用Excute方法
    //-------------------------------------------------------------------
    public override void Execute()
    {
        Debug.Log("Enter Demo1StartCommand Execute！");

        AudioManagerInstance.Init();
    }
}
