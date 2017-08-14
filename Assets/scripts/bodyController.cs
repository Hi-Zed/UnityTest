using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyController : MonoBehaviour {
	private Rigidbody playerRigidbody;
	private Vector3 direction;

	public float speed;

	// Use this for initialization
	void Start () {
		direction = new Vector3 (0.0f, 0.0f, 0.0f);
		playerRigidbody = transform.GetChild (0).gameObject.GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		if(moveHorizontal > 0.0f)
			direction.Set(1.0f, 0.0f, 0.0f);
		if(moveHorizontal < 0.0f)
			direction.Set(-1.0f, 0.0f, 0.0f);
		if(moveVertical > 0.0f)
			direction.Set(0.0f, 0.0f, 1.0f);
		if(moveVertical < 0.0f)
			direction.Set(0.0f, 0.0f, -1.0f);
		playerRigidbody.velocity = direction * speed;

		for (int i = 1; i < transform.childCount; i++) {
			Rigidbody bodyRigidbody = transform.GetChild (i).gameObject.GetComponent<Rigidbody> ();
			Vector3 follow = transform.GetChild (i - 1).position - transform.GetChild (i).position;
			if (follow.magnitude > 1.1f)
				bodyRigidbody.velocity = follow * speed * 0.75f;
		}
	}
}
