using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

	public GameManager gameManager;

	void OnTriggerEnter2D(Collider2D other)
	{
		gameManager.levelEnded = other.CompareTag ("Player");
	}
}
