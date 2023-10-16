using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingPlatform : MonoBehaviour
{
	public Transform leftLimit, rightLimit;
	public float deltaPos;

	Vector2 newPosition;
	Vector3 offset;
	float midPoint;
	bool reachedLimit;

	void Start()
	{
		midPoint = 0.01f;
		reachedLimit = false;
	}

	void Update()
	{
		midPoint += deltaPos;

		if (midPoint >= 1 || midPoint <= 0)
		{
			reachedLimit = true;
		}

		if (reachedLimit)
			deltaPos *= -1;
		reachedLimit = false;
	}

	void FixedUpdate()
	{
		newPosition = new Vector2(Mathf.Lerp(leftLimit.position.x, rightLimit.position.x, midPoint), transform.position.y);
		transform.position = newPosition;
	}

}
