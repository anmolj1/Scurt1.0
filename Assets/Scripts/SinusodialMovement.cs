﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusodialMovement : MonoBehaviour {

	public float moveSpeed = 5f;
	public float frequency = 20f;
	public float magnitude = 0.5f;
	bool facingRight = true;
	Vector3 pos, localScale;

	void Start () {

		pos = transform.position;
		localScale =  transform.localScale;

	}
	
	void Update () {
		
		CheckWhereToFace ();

		if (facingRight)
			MoveRight ();
		else
			MoveLeft ();
	}

	void CheckWhereToFace()
	{
		if (transform.position.x < 63f)
			facingRight = true;
		
		else if (transform.position.x > 90f)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;


		
		transform.localScale = localScale;

	}

	void MoveRight()
	{
		pos += transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

	void MoveLeft()
	{
		pos -= transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

}
