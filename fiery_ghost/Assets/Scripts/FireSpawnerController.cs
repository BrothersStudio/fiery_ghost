﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawnerController : MonoBehaviour {

	public GameObject player;
	public GameObject firePrefab;
	public float minDistFromPlayer;
	public float fireCooldown;
	public float xSpawn;
	public float ySpawn;

	private float cooldownTime = 0.0f;

	void Update () 
	{
		if (Time.time >= cooldownTime) 
		{
			Debug.Log("Spawned in fire");

			cooldownTime = Time.time + fireCooldown;

			Vector3 playerLocation = player.GetComponent<Transform> ().position;
			Vector3 spawnLocation = new Vector3(0.0f,0.0f,0.0f); 
			do 
			{
				spawnLocation = new Vector3 (
					               Random.Range (-xSpawn, xSpawn), 
					               Random.Range (-ySpawn, ySpawn), 
					               0.0f);
			} while (Vector3.Distance (playerLocation, spawnLocation) < minDistFromPlayer);

			Instantiate(firePrefab, spawnLocation, Quaternion.identity);
		}

	}
}
