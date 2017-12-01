//-------------------------------------------------------------------------------------
//	PatrolState.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

public class PatrolState : FSMState
{
    private int targetWayPoint;
    private Transform[] waypoints;
    private GameObject npc;
    private Rigidbody npcRd;
    private GameObject player;

    //public PatrolState patrolState = new PatrolState(waypoints);

    public PatrolState(Transform [] wp, GameObject npc,GameObject player)
    {
        stateID = StateID.Patrol;
        waypoints = wp;
        targetWayPoint = 0;
        this.npc = npc;
        npcRd = npc.GetComponent<Rigidbody>();
        this.player = player;
    }

    public override void DoBeforeEntering( )
    {
        Debug.Log("Entering state " + ID);
    }

    public override void DoUpdate()
    {
        //巡逻的运动
        PatrolMove();

        CheckTransition();



    }

    //巡逻的运动
    private void PatrolMove()
    {
        npcRd.velocity = npc.transform.forward * 3;
        Transform targetTrans = waypoints[targetWayPoint];
        Vector3 targetPosition = targetTrans.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
        if (Vector3.Distance(npc.transform.position, targetPosition) < 1)
        {
            targetWayPoint++;
            targetWayPoint %= waypoints.Length;
        }
    }

    //检查转换条件
    private void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position,npc.transform.position)<5)
        {
            fsm.PerformTransition(Transition.SawPlayer);
        }
    }


}
