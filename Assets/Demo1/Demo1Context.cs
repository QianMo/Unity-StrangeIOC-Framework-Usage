using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class Demo1Context : MVCSContext
{
    public Demo1Context(MonoBehaviour view) : base(view)
    {

    }


    protected override void mapBindings()
    {
        //base.mapBindings();

        //绑定开始事件，创建一个startcommand
        commandBinder.Bind(ContextEvent.START).To<Demo1StartCommand>();

        //commandBinder.Bind(ContextEvent.NEXT).To<Demo1NextCommand>();
    }
}
