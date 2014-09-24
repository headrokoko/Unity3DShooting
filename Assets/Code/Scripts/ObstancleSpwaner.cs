using UnityEngine;
using System.Collections;

public class ObstancleSpwaner : MonoBehaviour {

	public GameObject Obstancle;
	public int Number = 20;
	public float SpwanRangeX = 100.0f;
	public float SpwanRangeY = 100.0f;
	public float SpwanRangeZ = 100.0f;
	private Vector3 SpwanPos;
	// Use this for initialization
	void Start () {
		Spwan();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spwan(){
		int count;
		for(count = 0; count < Number; count++){
			SpwanPos.x = Random.Range(-SpwanRangeX,SpwanRangeX);
			SpwanPos.y = Random.Range(-SpwanRangeY,SpwanRangeY);
			SpwanPos.z = Random.Range(-SpwanRangeZ,SpwanRangeZ);

			Instantiate(Obstancle,SpwanPos,Obstancle.transform.rotation);
		}
	}
}
