using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour {


	//set up trigger event for collisions
	[SerializeField]private float speed = 6.0f;
    //death sound enemy
    
    [SerializeField] private AudioClip playerDeathClip;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] [Range(0f, 1.0f)] private float deathVolume = 0.5f;

    //need to get rigibody component
    private Rigidbody2D rb;//rigibody of this games object
	
	//target will find player positiion so enemy can move towards it
	private Transform target;

	[SerializeField]private int scoreValue=10;

	//==public fields==
	public int ScoreValue{get{return scoreValue;}}

	//declare the delehate type
	public delegate void EnemeyKilled(EnemyBehaviour enemy);

	//public static event for listener classes to 
	//implement using the += construct
	public static EnemeyKilled EnemeyKilledEvent;

	//==private methods ==
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
	    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//add some movements to the left
		//rb.velocity= Vector2.left*speed;
		if(Vector2.Distance(rb.position,target.position)>0){
		rb.position = Vector2.MoveTowards(rb.position,target.position,Time.deltaTime*speed);		
		}
	}


	private void OnTriggerEnter2D(Collider2D whatHitMe){
		//param is collider comp of whatever hit me -
		//different behaviour required
		//could check the tag type for the object
		//could check for different components

		var player = whatHitMe.GetComponent<PlayerMovement>();
		var bullet = whatHitMe.GetComponent<Bullet>();

		if(player)//if player != null
		{
            //inflict damage on player?

            //destroy enemy
            //play sound clip when dead
            AudioSource.PlayClipAtPoint(playerDeathClip, Camera.main.transform.position, deathVolume);

            Destroy(player.gameObject);
			Destroy(gameObject);
		}

		if(bullet)//if player != null
		{
            //destroy enemyship & bullet
            //play sound clip when dead
            AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathVolume);

            Destroy(bullet.gameObject);
			PublishEnemyKilledEvent();
			Destroy(gameObject);
		}


	}

	private void PublishEnemyKilledEvent()
	{
		//if anyone is listenting tell them obkect destroyed
		if(EnemeyKilledEvent != null){
			EnemeyKilledEvent(this);
		}
	}
}