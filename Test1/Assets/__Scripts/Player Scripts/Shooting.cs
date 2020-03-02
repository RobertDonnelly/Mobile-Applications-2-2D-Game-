using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private AudioClip shootClip;
    [SerializeField] [Range(0f, 1.0f)] private float shootVolume = 0.5f;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletSpeed = 50f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

     void Shoot()
    {
       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, shootVolume);
        bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
