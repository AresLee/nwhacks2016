using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	public float speed;

	private Rigidbody rb;
	float zMovement;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			zMovement = speed * (float)Time.fixedDeltaTime;
		}

		if(Input.GetKeyDown (KeyCode.LeftControl)) 
		{
			zMovement = -speed * (float)Time.fixedDeltaTime;
		}

		Vector3 movement = new Vector3 (moveHorizontal, zMovement, moveVertical);

		rb.AddForce (movement * speed);
	}

	
}
