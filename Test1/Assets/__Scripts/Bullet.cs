using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour {

	private Rigidbody2D rb;//rigibody of this games object


    // Update is called once per frame
    void Update () {
	if(transform.position.x > 100)
		{
			Destroy(gameObject);
		}
    else if (transform.position.x < -100)
        {
            Destroy(gameObject);
        }
    else if (transform.position.y > 100)
        {
            Destroy(gameObject);
        }
    else if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }		
}
