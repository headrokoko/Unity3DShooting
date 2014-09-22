using UnityEngine;
using System.Collections;

public class ObstanclesOperation : MonoBehaviour {

	public float rotX = 30.0f;
	public float rotY = 30.0f;
	public float rotZ = 30.0f;
	public float moveX = 10.0f;
	public float moveY = 10.0f;
	public float moveZ = 10.0f;
	
	float randomRotX;
	float randomRotY;
	float randomRotZ;
	float randomMoveX;
	float randomMoveY;
	float randomMoveZ;

	// Use this for initialization
	void Start () {
		randomRotX = Random.Range(-rotX,rotX);
		randomRotY = Random.Range(-rotY,rotY);
		randomRotZ = Random.Range(-rotZ,rotZ);
		randomMoveX = Random.Range(-moveX,moveX);
		randomMoveY = Random.Range(-moveY,moveY);
		randomMoveZ = Random.Range(-moveZ,moveZ);
		Operation();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Operation(){
		rigidbody.AddRelativeTorque(randomRotX,randomRotY,randomRotZ);
		rigidbody.AddForce(randomMoveX,randomMoveY,randomMoveZ);
	
	}
}
