//-------------------------------------------------------------------------------------
//	Demo1UpdateScoreCommand.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;


public class Demo1UpdateScoreCommand: EventCommand
{
    [Inject]
    public Demo1ScoreModel scoreModel { get; set; }

    [Inject]
    public Demo1IScoreService scoreService { get; set; }

    public override void Execute()
    {
        scoreModel.Score++;
        scoreService.UpdataScore("http://www.666666666.com", scoreModel.Score);

        dispatcher.Dispatch(Demo1Event.ScoreChange_Mediator, scoreModel.Score);
    }


}
