using UnityEngine;
using Assets.Code.InterFace;
using System.Collections;

namespace Assets.Code.States{	
	public class ResultState : GameInterFace {

		private GameStateManager Gmanager;
		private GameData GData;

		public ResultState(GameStateManager GStateManager){
			Gmanager = GStateManager;
		}

		public void StateUpdata(){

		}

		public void Render(){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),Gmanager.gData.ResultTex,ScaleMode.StretchToFill);
			if(GUI.Button(new Rect(500,500,200,50),"Back to Stage Select")){
				Gmanager.StateChange(new StageSelectState(Gmanager));
			}
		}
	}
}
