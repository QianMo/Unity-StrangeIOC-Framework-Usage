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
        //--------------------------model-------------------------------
        injectionBinder.Bind<Demo1ScoreModel>().To<Demo1ScoreModel>().ToSingleton();

        //--------------------------service------------------------------
        injectionBinder.Bind<Demo1IScoreService>().To<Demo1ScoreService>().ToSingleton();

        //--------------------------command--------------------------
        commandBinder.Bind(Demo1Event.RequestScore_Command).To<Demo1RequestScoreCommand>();
        commandBinder.Bind(Demo1Event.UpdateScore_Command).To<Demo1UpdateScoreCommand>();


        //--------------------------mediator---------------------------
        //进行view和mediator的绑定
        mediationBinder.Bind<Demo1CubeView>().To<Demo1CubeMediator>();

        //绑定开始事件，创建一个startcommand
        commandBinder.Bind(ContextEvent.START).To<Demo1StartCommand>();
        //commandBinder.Bind(ContextEvent.NEXT).To<Demo1NextCommand>();
    }
}
