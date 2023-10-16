using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointLengthManager : MonoBehaviour
{
	public Transform point1, point2;
	public float reduceFactor;
	public char axis;
	float distance;

	void Update()
	{
		if (axis == 'x')
			distance = point1.position.x - point2.position.x;
		else
			distance = point1.position.y - point2.position.y;
		transform.localScale = new Vector3(transform.localScale.x, distance / reduceFactor, 0);
	}
}
