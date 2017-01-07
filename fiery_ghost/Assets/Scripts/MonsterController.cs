using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

	public GameObject player;
	public float relativeSpeed;

	private float speed;

	void Start () {
		speed = relativeSpeed * player.GetComponent<PlayerController> ().playerSpeed;
	}
		
	void Update () {
		Vector3 playerPosition = GetComponent<Transform> ().position;
		Vector3 monsterPosition = this.GetComponent<Transform> ().position;

		float normalizationValue = Vector3.Distance (playerPosition, monsterPosition);

		Vector3 travelDirection = new Vector3(
			monsterPosition[0] - playerPosition[0], 
			monsterPosition[1] - playerPosition[1], 
			0.0f);

		Rigidbody2D rb2d = this.GetComponent<Rigidbody2D> ();

		Debug.Log(travelDirection);
		Debug.Log(speed);

		rb2d.AddForce ((travelDirection / normalizationValue) * speed);
	}
}
