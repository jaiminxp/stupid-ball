using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Knife"))
		{
			Vector3 theScale = other.transform.localScale;
			theScale.x *= -1;
			other.transform.localScale = theScale;
			Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
			rb.angularVelocity *= -1;
			float tempVel = rb.velocity.x;
			rb.velocity = new Vector2(-tempVel, 0);
		}
	}
}
