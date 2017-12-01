//-------------------------------------------------------------------------------------
//	FSMSystem.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 状态机管理类，有限状态机系统类
/// </summary>
public class FSMSystem
{
    //当前状态机下面有哪些状态
    private Dictionary<StateID, FSMState> states;

    //状态机处于什么状态
    private FSMState currentState;
    public FSMState CurrentState
    {
        get { return currentState; }
    }


    public FSMSystem()
    {
        states = new Dictionary<StateID, FSMState>();
    }

    /// <summary>
    /// 状态的添加
    /// </summary>
    public void AddState(FSMState state)
    {
        if (state == null )
        {
            Debug.LogError("The state you want to add is null.");
            return;
        }

        if (states.ContainsKey(state.ID))
        {
            Debug.LogError("The state" + state.ID + "you want to add has already been added.");
            return;
        }

        states.Add(state.ID, state);
    }

    /// <summary>
    /// 状态的删除
    /// </summary>
    public void DeleteState(FSMState state)
    {
        if (state == null)
        {
            Debug.LogError("The state you want to add is null.");
            return;
        }

        if (states.ContainsKey(state.ID)==false)
        {
            Debug.LogError("The state" + state.ID + "you want to delte is not exsit.");
            return;
        }

        states.Remove(state.ID);
    }


    public void PerformTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("nullTransition not allowed for Transition");
        }

        StateID id = currentState.GetOutputState(trans);
        if (id==StateID.NullStateID)
        {
            Debug.Log("Transition is not to be happened !没有符合条件的转换");
            return;
        }

        FSMState state;
        states.TryGetValue(id, out state);
        currentState.DoBeforeLeaving();
        currentState = state;
        currentState.DoBeforeEntering();
    }

    public void Start(StateID id)
    {
        FSMState state;
        bool isGet = states.TryGetValue(id, out state);
        if (isGet)
        {
            state.DoBeforeEntering();
            currentState = state;
        }
        else
        {
            Debug.LogError("the state " + id + "is not exsit ");
        }
    }

}
