using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //==publoic fields==

    [SerializeField]private float speed = 6.0f;

    public Rigidbody2D rb;//rigibody of this games object
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

  /*  void Start () {
      rb = this.GetComponent<Rigidbody2D>();
      cam = this.GetComponent<Camera>();
	}*/
	
	// Update is called once per frame
	void Update () {
        //Move();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos =  cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    /*	private void Move(){
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
        */
}
