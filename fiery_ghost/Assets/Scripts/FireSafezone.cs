using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireSafezone : MonoBehaviour {

	public AudioSource safezoneAudio;

	void OnTriggerStay2D(Collider2D other) 
	{
		if (other.tag == "Player" && !safezoneAudio.isPlaying) 
		{
			safezoneAudio.Play ();
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		safezoneAudio.Stop ();
	}
}