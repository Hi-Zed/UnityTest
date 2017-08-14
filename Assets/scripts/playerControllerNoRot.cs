using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControllerNoRot : MonoBehaviour {

	private int counter;

	public Text countText;
	public Text winText;
		
	void Start() {
		counter = 0;
		winText.text = "";
	}

	void Update () {
		countText.text = "SCORE: " + counter.ToString ();
		if (counter >= 12)
			winText.text = "YOU WIN!";
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("pickUp")) {
			other.gameObject.SetActive (false);
			counter++;
		}
	}
}
