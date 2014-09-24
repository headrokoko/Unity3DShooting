using UnityEngine;
using Assets.Code.InterFace;
using Assets.Code.States;

public class GameStateManager : MonoBehaviour {

	private GameInterFace actState;

	[HideInInspector]
	public GameData gData;
	public static GameStateManager inst;

	void Awake(){
		if(inst == null){
			inst = this;
			DontDestroyOnLoad(gameObject);
		}
		else{
			DestroyImmediate(gameObject);
		}
	}

	void OnGUI(){
		actState.Render();
	}

	// Use this for initialization
	void Start () {
		actState = new GameStartState(this);
		gData = GetComponent<GameData>();
	}
	
	// Update is called once per frame
	void Update () {
		if(actState != null){
			actState.StateUpdata();
		}
	}

	public void StateChange(GameInterFace nextState){
		actState = nextState;
		Debug.Log(actState);
	}
}
