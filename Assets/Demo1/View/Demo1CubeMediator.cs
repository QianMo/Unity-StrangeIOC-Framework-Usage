//-------------------------------------------------------------------------------------
//	Demo1CubeMediator.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;
using System.Collections.Generic;

public class Demo1CubeMediator : Mediator
{
    [Inject]
    public Demo1CubeView cubeView { get; set; }

    //全局dispatcher
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    [Inject]
    public Demo1ScoreModel scoreModel { get; set; }



    public override void OnRegister()
    {
        Debug.Log(cubeView);
        cubeView.Init();

        dispatcher.AddListener(Demo1Event.ScoreChange_Mediator, OnScoreChange);

        cubeView.dispatcher.AddListener(Demo1Event.ClickDown_Mediator, OnClickDown);
        //通过dispatcher，发起请求分数的命令
        dispatcher.Dispatch(Demo1Event.RequestScore_Command);


        cubeView.dispatcher.AddListener(Demo1Event.ClickDown_Mediator_Test, OnClickDown_Test);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1Event.ScoreChange_Mediator, OnScoreChange);
    }


    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int)evt.data);
    }

    public void OnClickDown()
    {
        dispatcher.Dispatch(Demo1Event.UpdateScore_Command);
    }

    public void OnClickDown_Test(IEvent evt)
    {
        List<object> listData = (List<object>)evt.data;

        var a = listData[0];
        var b = listData[1];
        var c = listData[2];
        var d = listData[3];
    }


}
