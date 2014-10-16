﻿using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
	//被弾時の爆発のエフェクト
	public GameObject Explosion;
	public float Speed = 100.0f;
	public float LifeTime = 3.0f;
	public int damage = 50;
	
	void Start()
	{
		Destroy(gameObject, LifeTime);
	}
	
	void Update()
	{

		transform.position += 
			transform.forward * Speed * Time.deltaTime;    

	}
	
	void OnCollisionEnter(Collision collision)
	{
		ContactPoint contact = collision.contacts[0];
		Instantiate(Explosion, contact.point, Quaternion.identity);
		Destroy(gameObject);
	}
}