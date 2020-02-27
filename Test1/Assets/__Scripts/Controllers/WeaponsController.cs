using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour {

	[SerializeField]private float bulletSpeed = 10.0f;
	[SerializeField]private Bullet bulletPreFab;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] [Range(0f, 1.0f)] private float shootVolume = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			//check if user press fire button
			if(Input.GetKeyDown(KeyCode.Space)){
				FireBullet();
			}	
	}

	private void FireBullet(){
		Bullet bullet = Instantiate(bulletPreFab);
        AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, shootVolume);
        bullet.transform.position = transform.position;
		Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
		rbb.velocity=Vector2.right * bulletSpeed;

    }
}
