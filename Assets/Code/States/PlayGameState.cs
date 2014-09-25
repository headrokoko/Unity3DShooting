using UnityEngine;
using System.Collections;
using Assets.Code.InterFace;

namespace Assets.Code.States{
	public class PlayGameState : GameInterFace {
		private GameStateManager Gmanager;
		private GameData gamedata;
		private PlayerController Pcontroller;

		public PlayGameState(GameStateManager GstateManager){
			Gmanager = GstateManager;
			gamedata = GameObject.Find("GameManager").GetComponent<GameData>();
			Pcontroller = GameObject.Find("Player").GetComponent<PlayerController>();
		}

		public void StateUpdata(){
			if(gamedata.playerHP <= 0){
				Gmanager.StateChange(new ResultState(Gmanager));
				Pcontroller.PlayerSpeed = 0.0f;
			}
		}

		public void Render(){
			if(GUI.Button(new Rect(500,500,100,50),"Result")){
				Pcontroller.PlayerSpeed = 0;
				Gmanager.StateChange(new ResultState(Gmanager));
			}
		}

	}
}
