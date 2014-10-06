using UnityEngine;
using System.Collections;

public class AttackMode : FSMState
{
	public AttackMode(Transform[] wp) 
	{ 
		waypoints = wp;
		stateID = FSMStateID.Attacking;
		curRotSpeed = 1.0f;
		curSpeed = 100.0f;
		FindNextPoint();
	}
	
	public override void Reason(Transform player, Transform npc)
	{
		//
		float dist = Vector3.Distance(npc.position, player.position);
		if (dist >= 200.0f && dist < 300.0f)
		{
			//
			Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
			
			//
			npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
			
			Debug.Log("Switch to Chase State");
			npc.GetComponent<EnemyController>().SetTransition(Transition.SawPlayer);
		}
		//
		else if (dist >= 300.0f)
		{
			Debug.Log("Switch to Patrol State");
			npc.GetComponent<EnemyController>().SetTransition(Transition.LostPlayer);
		}  
	}
	
	public override void Act(Transform player, Transform npc)
	{
		//
		destPos = player.position;
		
		//
		Transform turret = npc.GetComponent<EnemyController>().turret;
		Quaternion turretRotation = Quaternion.LookRotation(destPos - turret.position);
		turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
		
		//
		npc.GetComponent<EnemyController>().ShootBullet();
	}
}