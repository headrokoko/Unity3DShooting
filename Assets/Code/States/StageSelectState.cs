using UnityEngine;
using System.Collections;
using Assets.Code.InterFace;
using Assets.Code.States;

namespace Assets.Code.States{
	public class StageSelectState : GameInterFace {

		private GameStateManager Gmanager;
		private PlayerController Pcontroller;

		public StageSelectState(GameStateManager GStateManager){
			Gmanager = GStateManager;
			Pcontroller = GameObject.Find("Player").GetComponent<PlayerController>();
			Time.timeScale = 0;
		}

		public void StateUpdata(){
		}

		public void Render(){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),Gmanager.gData.StageSelectTex,ScaleMode.StretchToFill);

			if(GUI.Button(new Rect(05,200,250,50),"Stage 1")){
				Application.LoadLevel("Stage1");
				Time.timeScale = 1;
				Pcontroller.PlayerSpeed = 10.0f;
				Debug.Log("Stage 1 start");
				Gmanager.StateChange(new PlayGameState(Gmanager));
			}

			else if(GUI.Button(new Rect(05,250,250,50),"Stage 2")){
				Application.LoadLevel("Stage2");
				Time.timeScale = 1;
				Pcontroller.PlayerSpeed = 10.0f;
				Debug.Log("Stage 2 start");
				Gmanager.StateChange(new PlayGameState(Gmanager));
			}
			
			else if(GUI.Button(new Rect(05,300,250,50),"Stage 3")){
				Application.LoadLevel("Stage3");
				Time.timeScale = 1;
				Pcontroller.PlayerSpeed = 10.0f;
				Debug.Log("Stage 3 start");
				Gmanager.StateChange(new PlayGameState(Gmanager));
			}
			
			else if(GUI.Button(new Rect(05,350,250,50),"TEST")){
				Application.LoadLevel("testScene");
				Time.timeScale = 1;
				Pcontroller.PlayerSpeed = 10.0f;
				Debug.Log("testScene start");
				Gmanager.StateChange(new PlayGameState(Gmanager));
			}
		}
	}
}
