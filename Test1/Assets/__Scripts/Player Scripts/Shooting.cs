using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private AudioClip shootClip;
    [SerializeField] [Range(0f, 1.0f)] private float shootVolume = 0.5f;
    [SerializeField] private float firingRate = 0.25f;
    [SerializeField] private float bulletSpeed = 50f;

    private Coroutine firingCoroutine;

    public Transform firePoint;
    public GameObject bulletPrefab;

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
           // Shoot();
            firingCoroutine = StartCoroutine(FireCoroutine());

        }
        if (Input.GetButtonUp("Fire1"))
        {
            //StopAllCoroutines();    // not good, sledgehammer approach
            StopCoroutine(firingCoroutine);
        }
    }

  /*   void Shoot()
    {
       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, shootVolume);
        bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }*/

    // coroutine returns an IEnumerator type
    private IEnumerator FireCoroutine()
    {
        while (true)
        {
            // create a bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
            AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, shootVolume);
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            // sleep for short time
            yield return new WaitForSeconds(firingRate); // pick a number!!!
        }
    }

}
