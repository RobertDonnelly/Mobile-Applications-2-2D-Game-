using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// use this to manage collisions

public class Enemy : MonoBehaviour
{
    // == set this up to publish an event to the system
    // == when killed

    // == public fields ==
    // used from GameController enemy.ScoreValue
    public int ScoreValue { get { return scoreValue; } }

    // delegate type to use for event
    public delegate void EnemyKilled(Enemy enemy);

    // create static method to be implemented in the listener
    public static EnemyKilled EnemyKilledEvent;

    //death sound enemy
    [SerializeField] private AudioClip playerDeathClip;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] [Range(0f, 1.0f)] private float deathVolume = 0.5f;

 

    [SerializeField] private int scoreValue = 10;

    //declare the delehate type
    public delegate void EnemeyKilled(Enemy enemy);

    //public static event for listener classes to 
    //implement using the += construct
    public static EnemeyKilled EnemeyKilledEvent;

    // == private fields ==
    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        //param is collider comp of whatever hit me -
        //different behaviour required
        //could check the tag type for the object
        //could check for different components

        var player = whatHitMe.GetComponent<PlayerMovement>();
        var bullet = whatHitMe.GetComponent<Bullet>();

        if (player)//if player != null
        {
            //inflict damage on player?

            //destroy enemy
            //play sound clip when dead
            AudioSource.PlayClipAtPoint(playerDeathClip, Camera.main.transform.position, deathVolume);

            Destroy(player.gameObject);
            Destroy(gameObject);
        }

        if (bullet)//if player != null
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
        if (EnemeyKilledEvent != null)
        {
            EnemeyKilledEvent(this);
        }
    }
}
