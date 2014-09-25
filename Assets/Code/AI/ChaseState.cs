using UnityEngine;
using System.Collections;
 
public class ChaseState : FSMState
{
    public ChaseState(Transform[] wp) 
    { 
        waypoints = wp;
        stateID = FSMStateID.Chasing;
 
        curRotSpeed = 1.0f;
        curSpeed = 100.0f;
 
        FindNextPoint();
    }
 
    public override void Reason(Transform player, Transform npc)
    {
        destPos = player.position;
 
        float dist = Vector3.Distance(npc.position, destPos);
        if (dist <= 200.0f)
        {
            Debug.Log("Switch to Attack state");
            npc.GetComponent<NPCController>().SetTransition(Transition.ReachPlayer);
        }
        else if (dist >= 300.0f)
        {
            Debug.Log("Switch to Patrol state");
            npc.GetComponent<NPCController>().SetTransition(Transition.LostPlayer);
        }
    }
 
    public override void Act(Transform player, Transform npc)
    {
        destPos = player.position;
 
        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
 
        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }
}