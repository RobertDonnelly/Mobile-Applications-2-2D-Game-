using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	//==priavte field==
	private int playerScore = 0;
	
	private void OnEnable(){
		EnemyBehaviour.EnemeyKilledEvent+=HandleEnemyKilledEvent;

	}
	
	private void OnDisable(){
		EnemyBehaviour.EnemeyKilledEvent-=HandleEnemyKilledEvent;

	}

	private void HandleEnemyKilledEvent(EnemyBehaviour enemy){
		playerScore += enemy.ScoreValue;//public property
		Debug.Log(enemy.ScoreValue+" points!");
		Debug.Log("Score:"+playerScore);
	}
	
}
