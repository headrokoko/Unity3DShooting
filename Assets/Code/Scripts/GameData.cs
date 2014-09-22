using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public int MaxPlayerHP = 100;
	[HideInInspector]
	public int playerHP;
	[HideInInspector]
	public int score;

	public Texture2D StartTex;
	public Texture2D StageSelectTex;
	public Texture2D ResultTex;


	// Use this for initialization
	void Start () {
		playerHP = MaxPlayerHP;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
