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

    //public PatrolState patrolState = new PatrolState(waypoints);

    public PatrolState(Transform [] wp, GameObject npc)
    {
        stateID = StateID.Patrol;
        waypoints = wp;
        targetWayPoint = 0;
        this.npc = npc;
        npcRd = npc.GetComponent<Rigidbody>();
    }

    public override void DoBeforeEntering( )
    {
        Debug.Log("Entering state " + ID);
    }

    public override void DoUpdate()
    {
        npcRd.velocity = npc.transform.forward * 3;
        Transform targetTrans = waypoints[targetWayPoint];
        Vector3 targetPosition = targetTrans.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
        if (Vector3.Distance(npc.transform.position,targetPosition)<1)
        {
            targetWayPoint++;
            targetWayPoint %= waypoints.Length;
        }

    }
}
