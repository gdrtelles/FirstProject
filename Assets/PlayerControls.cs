using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
			

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.


	
	void FixedUpdate() {
	
			float moveleft = Input.GetAxis("left");
			float moveright = Input.GetAxis("right");
			float moveup = Input.GetAxis("up");
			float movedown = Input.GetAxis("down");
			
			
			rigidbody2D.AddForce(-Vector2.right * moveleft * moveForce);
			rigidbody2D.AddForce(Vector2.right * moveright * moveForce);
			
			// If the player's horizontal velocity is greater than the maxSpeed...
			if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
				// ... set the player's velocity to the maxSpeed in the x axis.
				rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);


			
			
			rigidbody2D.AddForce(Vector2.up * moveup * moveForce);
			rigidbody2D.AddForce(-Vector2.up * movedown * moveForce);
			
			// If the player's horizontal velocity is greater than the maxSpeed...
			if(Mathf.Abs(rigidbody2D.velocity.y) > maxSpeed)
				// ... set the player's velocity to the maxSpeed in the x axis.
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Sign(rigidbody2D.velocity.y) * maxSpeed);
			
			
	}
	

	
}

