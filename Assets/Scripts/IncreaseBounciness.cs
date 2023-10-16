using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBounciness : MonoBehaviour
{
	public float increaseFactor;
	public PhysicsMaterial2D bouncy;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
			bouncy.bounciness *= increaseFactor;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
			bouncy.bounciness /= increaseFactor;
	}
}
