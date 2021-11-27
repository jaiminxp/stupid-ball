using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMover : MonoBehaviour 
{
	public float speed;
	Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = Vector2.right * speed;
	}

}
