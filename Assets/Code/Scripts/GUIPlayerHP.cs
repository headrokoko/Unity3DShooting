using UnityEngine;
using System.Collections;

public class GUIPlayerHP : MonoBehaviour {

	public GameData gamedata;

	// Use this for initialization
	void Start () {
		gamedata = GameObject.Find("GameManager").GetComponent<GameData>();
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Player HP :" + gamedata.playerHP.ToString();
	
	}
}
