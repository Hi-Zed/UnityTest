using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	private int counter;
	private Rigidbody rigidBody;

	public float speed;
	public Text countText;
	public Text winText;
		
	void Start() {
		counter = 0;
		rigidBody = GetComponent<Rigidbody>();
		winText.text = "";
	}

	void Update () {
		countText.text = "SCORE: " + counter.ToString ();
		if (counter >= 12)
			winText.text = "YOU WIN!";
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidBody.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("pickUp")) {
			other.gameObject.SetActive (false);
			counter++;
		}
	}
}
