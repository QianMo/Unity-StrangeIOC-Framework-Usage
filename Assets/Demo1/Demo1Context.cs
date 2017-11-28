using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;

public class Demo1Context : MVCSContext
{
    public Demo1Context(MonoBehaviour view) : base(view)
    {

    }


    protected override void mapBindings()
    {
        base.mapBindings();
    }
}
