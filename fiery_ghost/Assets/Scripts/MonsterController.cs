using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour {

	public GameObject playerHealthbar;

	public GameObject player;

	public float damage;
	public float speed;

    int targetIndex;
    
    Vector2[] path;

	void Start () 
    {
        StartCoroutine (RefreshPath ());
	}
    
	IEnumerator RefreshPath() 
    {
		Vector2 targetPositionOld = (Vector2)player.GetComponent<Transform> ().position + Vector2.up; // ensure != to target.position initially
			
		while (true) {
			if (targetPositionOld != (Vector2)player.GetComponent<Transform> ().position) 
            {
				targetPositionOld = (Vector2)player.GetComponent<Transform> ().position;

				path = Pathfinding.RequestPath (transform.position, player.GetComponent<Transform> ().position);
				StopCoroutine ("FollowPath");
				StartCoroutine ("FollowPath");
			}

			yield return new WaitForSeconds (.25f);
		}
	}    
    
	IEnumerator FollowPath() 
    {
		if (path.Length > 0) 
        {
			targetIndex = 0;
			Vector2 currentWaypoint = path [0];

			while (true) 
            {
				if ((Vector2)transform.position == currentWaypoint) 
                {
					targetIndex++;
					if (targetIndex >= path.Length) {
						yield break;
					}
					currentWaypoint = path [targetIndex];
				}
					
				transform.position = Vector2.MoveTowards (transform.position, currentWaypoint, speed * Time.deltaTime);
				yield return null;

			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			Destroy (this.gameObject);
			GetComponentInParent<MonsterSpawnerController> ().monsterExists = false;

			playerHealthbar.GetComponent<Image> ().fillAmount = playerHealthbar.GetComponent<Image> ().fillAmount - damage;
		}
	}
}
