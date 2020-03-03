using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour {
    
    //need to get rigibody component
    private Rigidbody2D rb;//rigibody of this games object

    //set up trigger event for collisions
    [SerializeField]private float speed = 6.0f;

    //target will find player positiion so enemy can move towards it
    private Transform target;

    


    //==private methods ==
    void Start () {
		rb = this.GetComponent<Rigidbody2D>();
	    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {
        //add some movements to the left
        //rb.velocity= Vector2.left*speed;
      //  transform.LookAt(target);
       // transform.LookAt(target, Vector3.left);

         Vector3 vectorToTarget = target.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

        if (Vector2.Distance(rb.position,target.position)>0){
		rb.position = Vector2.MoveTowards(rb.position,target.position,Time.deltaTime*speed);
        }
	}

}