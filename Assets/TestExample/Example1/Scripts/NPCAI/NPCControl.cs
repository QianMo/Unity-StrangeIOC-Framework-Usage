//-------------------------------------------------------------------------------------
//	NPCControl.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class NPCControl : MonoBehaviour
{
    private FSMSystem fsm;
    private GameObject player;

    public Transform[] waypoints;

	//-----------------------------------------【Start()函数】---------------------------------------------
	// 说明：此函数仅在Update函数第一次被调用前被调用，常用于进行数据的初始化
	//-----------------------------------------------------------------------------------------------------
	void Start ( )
	{
        player = GameObject.FindGameObjectWithTag("Player");
        InitFSM();

    }

    /// <summary>
    /// 初始化FSM
    /// </summary>
    void InitFSM()
    {
        fsm = new FSMSystem();


        PatrolState patrolState = new PatrolState(waypoints,this.gameObject, player);
        patrolState.AddTransition(Transition.SawPlayer,StateID.Chase);

        ChaseState chaseState = new ChaseState(this.gameObject,player);
        chaseState.AddTransition(Transition.LostPlayer, StateID.Patrol);


        fsm.AddState(patrolState);
        fsm.AddState(chaseState);

        fsm.Start(StateID.Patrol);
    }


    private void Update()
    {
        fsm.CurrentState.DoUpdate();
    }

}
