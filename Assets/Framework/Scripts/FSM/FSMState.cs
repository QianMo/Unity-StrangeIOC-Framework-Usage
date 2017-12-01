//-------------------------------------------------------------------------------------
//	FSMState.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//有哪些状态转换的条件
public enum Transition
{
    NullTransition = 0,
    SawPlayer,//看到玩家
    LostPlayer,//丢失玩家
}

//状态ID，是每一个状态的唯一标识，一个状态有一个stateid，而且跟其他的状态不可重复
public enum StateID
{
    NullStateID = 0,
    Patrol,//巡逻状态
    Chase,//追主角状态
}

//放置每一个状态共有的功能
public abstract class FSMState
{
    protected StateID stateID;

    public StateID ID
    {
        get { return stateID; }
    }

    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();

    public void AddTransition(Transition trans, StateID id)
    {
        if (trans==Transition.NullTransition || id ==StateID.NullStateID)
        {
            Debug.LogError("Transition or stateid is null");
            return;
        }

        if (map.ContainsKey(trans))
        {
            Debug.LogError("State "+ stateID +"is already has transition "+trans);
            return;
        }

        map.Add(trans, id);
    }


    public void DeleteTransition(Transition trans)
    {
        if (map.ContainsKey(trans)== false)
        {
            Debug.LogWarning("The transition " + trans + "you want to delete is not exit in map!");
            return;
        }
        map.Remove(trans);
    }

    //根据传递过来的转换条件，判断一下是否可以发生转换
    public StateID GetOutputState(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateID.NullStateID;
    }

    public virtual void DoBeforeEntering() { }

    public virtual void DoBeforeLeaving() { }

    //在状态机处于当前状态时，会一直调用
    public abstract void DoUpdate();

   
}
