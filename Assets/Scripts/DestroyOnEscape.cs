using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEscape : MonoBehaviour
{
	public int limit;

	void Update()
	{
		if (transform.position.x >= limit)
			Destroy(gameObject);
	}
}
