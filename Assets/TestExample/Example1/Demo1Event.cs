﻿//-------------------------------------------------------------------------------------
//	Demo1Event.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public enum Demo1Event
{
    //COMMANDEVENT
    RequestScore_Command=1,
    UpdateScore_Command,

    //service
    RequestScore_Service =10000,


    //mediater
    ScoreChange_Mediator=20000,

    ClickDown_Mediator,
    ClickDown_Mediator_Test

}
