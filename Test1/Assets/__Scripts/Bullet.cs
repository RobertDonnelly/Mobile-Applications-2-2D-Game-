using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour {

	private Rigidbody2D rb;//rigibody of this games object


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	if(transform.position.x > 40)//if player != null
		{
			//destroy enemyship & bullet
			//play sound clip when dead
			Destroy(gameObject);
		}

		
	}		
}
