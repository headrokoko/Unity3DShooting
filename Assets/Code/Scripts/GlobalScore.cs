using UnityEngine;
using System.Collections;

public static class GlobalScore  {
	public static float score = 0;
	public static void GetScore(){
		
		score += 50;
	}

}