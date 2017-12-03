using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

public class Demo1ContextView : ContextView
{

    void Awake()
    {
        this.context = new Demo1Context(this);

        Debug.Log("StrangeIOC Init Finish~!!");

        //启动StrangeIOC框架
        //context.Start();
    }
}
