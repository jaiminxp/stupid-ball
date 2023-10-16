using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
	public Transform player, leftLimit, rightLimit;
	Vector3 offset, newPosition;

	void Start()
	{
		offset.x = player.position.x - transform.position.x;
	}


	void LateUpdate()
	{
		transform.position = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
		newPosition = new Vector3(
		Mathf.Clamp(transform.position.x, leftLimit.position.x, rightLimit.position.x),
		transform.position.y, transform.position.z);
		transform.position = newPosition;
	}
}
