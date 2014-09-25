using UnityEngine;
using System.Collections;
using Assets.Code.InterFace;

namespace Assets.Code.States{
	public class GameStartState : GameInterFace {

		private GameStateManager GManager;
		private PlayerController Pcontroller;

		public GameStartState(GameStateManager GStateManager){
			GManager = GStateManager;
			Pcontroller = GameObject.Find("Player").GetComponent<PlayerController>();
			Pcontroller.enabled = false;
			Time.timeScale = 0;
		}

	// Use this for initialization
	public void StateUpdata () {
		
	}
	
	// Update is called once per frame
	public void Render () {
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),GManager.gData.StartTex,ScaleMode.StretchToFill);
		
			if(GUI.Button(new Rect(250,450,250,50),"Game Start")){
				Debug.Log("Start →　StageSelect");
				GManager.StateChange(new StageSelectState(GManager));
			}
	}
	}
}
