using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float BaseSpeed = 10.0f;
	public float RollSpeed = 5.0f;
	public float PitchSpeed = 5.0f;
	public float MaxSpeed = 50.0f;
	public float MinSpeed = 0.0f;

	private float PlayerSpeed;

	// Use this for initialization
	void Start () {
		PlayerSpeed = BaseSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * PlayerSpeed * 0.01f);
		//ロール運動
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate(0,0,RollSpeed);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(0,0,-RollSpeed);
		}

		//ピッチ運動
		if(Input.GetKey(KeyCode.W)){
			transform.Rotate(PitchSpeed,0.0f,0.0f);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Rotate(-PitchSpeed,0.0f,0.0f);
		}

		//加減速
		if(Input.GetKey(KeyCode.Q) && (PlayerSpeed < MaxSpeed)){
			PlayerSpeed += 1.0f;
		}

		if(Input.GetKey(KeyCode.E) && (PlayerSpeed > MinSpeed)){
			PlayerSpeed -= 1.0f;
		}
		
	}
}
