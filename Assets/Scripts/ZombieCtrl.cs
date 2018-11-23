using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCtrl : MonoBehaviour {

	// Use this for initialization

	public float speed = -2f;
	Rigidbody2D rb;
	SpriteRenderer sr;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move() {
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("TurnArround")) {
			Flip();
		}
	}

	void Flip() {
		speed = -speed;
		if (speed > 0) {
			sr.flipX = true;
		}
		else if (speed < 0) {
			sr.flipX = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Shoot") {
			Destroy(this.gameObject);
		}
	}
}
