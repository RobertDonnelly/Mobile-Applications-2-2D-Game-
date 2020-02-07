using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
//==publoic fields==
[SerializeField]private float speed = 6.0f;
private Rigidbody2D rb;//rigibody of this games object
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}	

	private void Move(){
			//get the movement on the predefinded axes
		float VMove = Input.GetAxis("Vertical");
		float HMove = Input.GetAxis("Horizontal");


		//generate some vertical movement
		rb.velocity = new Vector2(HMove * speed, VMove*speed);

		//constrain the player so they cant leavecamera view
		//useful method mathf.clamp
		//restricts a value between a lower & upper limit
		//Mathf.Clamp|(x,min,max)
	//Mathf.Clamp(transform.position.x,,)
	}
}
