using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject PlayerBullet;
	private Transform bulletSpawnPoint;
	private Transform Turret;
	private float BulletLimit = 10;
	public float BulletQuantity = 0;
	public float BaseSpeed = 10.0f;
	public float RollSpeed = 5.0f;
	public float PitchSpeed = 5.0f;
	public float MaxSpeed = 50.0f;
	public float MinSpeed = 0.0f;
	
	[HideInInspector]
	public float PlayerSpeed;

	// Use this for initialization
	void Start () {
		PlayerSpeed = BaseSpeed;
		Turret = gameObject.transform.GetChild(0).transform;
		bulletSpawnPoint = Turret.GetChild(0).transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * PlayerSpeed * 0.01f);
		//x軸移動
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(-BaseSpeed,0,0);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(BaseSpeed,0,0);
		}

		//ピッチ運動
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(0,0,BaseSpeed);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(0,0,-BaseSpeed);
		}

		//加減速
		if(Input.GetKey(KeyCode.Q) && (PlayerSpeed < MaxSpeed)){
			transform.Translate(0,BaseSpeed,0);
		}

		if(Input.GetKey(KeyCode.E) && (PlayerSpeed > MinSpeed)){
			transform.Translate(0,-BaseSpeed,0);
		}
		if(Input.GetKey(KeyCode.Space))
		{

				Instantiate(PlayerBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

		}
	}
}
