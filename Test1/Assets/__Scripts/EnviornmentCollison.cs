using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviornmentCollison : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        //param is collider comp of whatever hit me -
        //different behaviour required
        //could check the tag type for the object
        //could check for different components

        var bullet = whatHitMe.GetComponent<Bullet>();

        

        if (bullet)//if player != null
        {
            //destroy enemyship & bullet
            //play sound clip when dead

            Destroy(bullet.gameObject);
        }


    }
}
