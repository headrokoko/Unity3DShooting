using UnityEngine;
using System.Collections;

public class PlayScore : MonoBehaviour {

	public float score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = "Score : " + GlobalScore.score;


	}


}
