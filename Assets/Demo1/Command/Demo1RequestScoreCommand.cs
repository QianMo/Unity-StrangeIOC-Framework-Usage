//-------------------------------------------------------------------------------------
//	Demo1RequestScoreCommand.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;

public class Demo1RequestScoreCommand : Command
{
    [Inject]
    public Demo1IScoreService scoreService { get; set; }

    //全局dispatcher
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    public override void Execute()
    {
        scoreService.dispatcher.AddListener(Demo1Event.RequestScore_Service, OnComplete);
        scoreService.RequestScore("http://www.6666666666666666.com");
    }

    //IEvent存储的就是参数
    public void OnComplete(IEvent evt)
    {
        Debug.Log("Demo1RequestScoreCommand : On request score Complete!"+evt.data);

        scoreService.dispatcher.RemoveListener(Demo1Event.RequestScore_Service, OnComplete);

        dispatcher.Dispatch(Demo1Event.ScoreChange_Mediator,evt.data);

        Release();
    }
}
