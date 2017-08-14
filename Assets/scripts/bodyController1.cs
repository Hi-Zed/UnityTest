using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyController1 : MonoBehaviour {

	private Rigidbody playerRigidBody;
	private Vector3 direction;
	private Transform playerTransform;
	private List<Vector3> playerPath;
	private Vector3 lastPose;

	public float speed;

	// Use this for initialization
	void Start () {
		playerPath = new List<Vector3> ();
		direction = new Vector3 (1.0f * speed, 0.0f, 0.0f);
		playerTransform = transform.GetChild (0);
		playerRigidBody = playerTransform.gameObject.GetComponent<Rigidbody>();
		lastPose = playerTransform.position;
	}

	void FixedUpdate () {
		if (playerPath.Count == (transform.childCount - 1))
			playerPath.RemoveAt (0);
		if (Vector3.Distance(lastPose, playerTransform.position) >= 1f) {
			playerPath.Add (playerTransform.position);
			lastPose = playerTransform.position;
		}

		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//		transform.Translate (movement * speed);

		if(moveHorizontal > 0.0f)
			direction.Set(1.0f, 0.0f, 0.0f);
		if(moveHorizontal < 0.0f)
			direction.Set(-1.0f, 0.0f, 0.0f);
		if(moveVertical > 0.0f)
			direction.Set(0.0f, 0.0f, 1.0f);
		if(moveVertical < 0.0f)
			direction.Set(0.0f, 0.0f, -1.0f);

		playerRigidBody.velocity = direction * speed;
	}

	void LateUpdate() {
		Debug.Log (playerPath.Count);
		if (playerPath.Count > 0) {
			transform.GetChild (1).position = playerPath [playerPath.Count - 1];
		}
//		for (int i = 1; i < transform.childCount - 1; i++)
//			transform.GetChild (i).position = playerPath [playerPath.Count - i - 1];
	}
}
