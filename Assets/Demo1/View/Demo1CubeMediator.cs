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

public class Demo1CubeMediator : Mediator
{
    [Inject]
    public Demo1CubeView cubeView { get; set; }

    //全局dispatcher
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    public override void OnRegister()
    {
        Debug.Log(cubeView);
        cubeView.Init();

        dispatcher.AddListener(Demo1Event.ScoreChange_Mediator, OnScoreChange);

        //通过dispatcher，发起请求分数的命令
        dispatcher.Dispatch(Demo1Event.RequestScore_Command);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1Event.ScoreChange_Mediator, OnScoreChange);
    }


    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int)evt.data);
    }
}
