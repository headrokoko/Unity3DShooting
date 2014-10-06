using UnityEngine;
using System.Collections;

public class EnemyController : AdvancedFSM 
{
	
	public GameObject EnemyBullet;
	private int HP;
	
	//
	protected override void Initialize()
	{
		HP = 100;
		
		elapsedTime = 0.0f;
		shootDelay = 0.1f;
		
		GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
		playerTransform = objPlayer.transform;
		
		if (!playerTransform)
			print("プレーヤーが存在しません。タグ 'Player'　を追加してください。");
		
		//　
		turret = gameObject.transform.GetChild(0).transform;
		bulletSpawnPoint = turret.GetChild(0).transform;
		
		// 
		ConstructFSM();
	}
	
	protected override void FSMUpdate()
	{
		//　
		elapsedTime += Time.deltaTime;
	}
	
	protected override void FSMFixedUpdate()
	{
		CurrentState.Reason(playerTransform, transform);
		CurrentState.Act(playerTransform, transform);
	}
	
	public void SetTransition(Transition t) 
	{ 
		PerformTransition(t); 
	}
	
	private void ConstructFSM()
	{
		//
		pointList = GameObject.FindGameObjectsWithTag("WandarPoint");
		
		Transform[] waypoints = new Transform[pointList.Length];
		int i = 0;
		foreach(GameObject obj in pointList)
		{
			waypoints[i] = obj.transform;
			i++;
		}
		
		PatrolMode patrol = new PatrolMode(waypoints);
		patrol.AddTransition(Transition.SawPlayer, FSMStateID.Chasing);
		patrol.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		ChaseMode chase = new ChaseMode(waypoints);
		chase.AddTransition(Transition.LostPlayer, FSMStateID.Patrolling);
		chase.AddTransition(Transition.ReachPlayer, FSMStateID.Attacking);
		chase.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		AttackMode attack = new AttackMode(waypoints);
		attack.AddTransition(Transition.LostPlayer, FSMStateID.Patrolling);
		attack.AddTransition(Transition.SawPlayer, FSMStateID.Chasing);
		attack.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		DeadMode dead = new DeadMode();
		dead.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		AddFSMState(patrol);
		AddFSMState(chase);
		AddFSMState(attack);
		AddFSMState(dead);
	}
	
	//　
	void OnCollisionEnter(Collision collision)
	{
		//
		if (collision.gameObject.tag == "PlayerBullet")
		{
			HP -= 50;
			Debug.Log("Enemy Damage");
			if (HP <= 0)
			{
				Debug.Log("Switch to Dead State");
				SetTransition(Transition.NoHealth);
				Explode();
			}
		}
	}
	
	protected void Explode()
	{
		float rndX = Random.Range(10.0f, 30.0f);
		float rndZ = Random.Range(10.0f, 30.0f);
		for (int i = 0; i < 3; i++)
		{
			rigidbody.AddExplosionForce(10000.0f, transform.position - new Vector3(rndX, 10.0f, rndZ), 40.0f, 10.0f);
			rigidbody.velocity = transform.TransformDirection(new Vector3(rndX, 20.0f, rndZ));
		}
		
		Destroy(gameObject, 1.5f);
	}
	
	public void ShootBullet()
	{
		if (elapsedTime >= shootDelay)
		{
			Instantiate(EnemyBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
			elapsedTime = 0.0f;
		}
	}
}