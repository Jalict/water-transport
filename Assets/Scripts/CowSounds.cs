﻿using UnityEngine;
using System.Collections;

public class CowSounds : MonoBehaviour {
	public AudioClip cowSound;
	public AudioClip cowCollisionSound;
	float timer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += timer * Time.deltaTime;
		if(timer>=250){
			AudioSource.PlayClipAtPoint(cowSound, transform.position);
			timer = 0f;
		}
	}
	void OnCollisionEnter(Collision collision){
		AudioSource.PlayClipAtPoint(cowCollisionSound, transform.position);
	}
}
