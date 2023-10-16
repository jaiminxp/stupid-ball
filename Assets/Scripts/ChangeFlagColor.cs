using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFlagColor : MonoBehaviour
{
	public GameManager gameManager;
	public int AssignedIndex;

	SpriteRenderer FlagSpriteRenderer;

	void Start()
	{
		FlagSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		FlagSpriteRenderer.color = new Color(1, 0, 0, 1);
	}

	void Update()
	{
		if (gameManager.index - 1 == AssignedIndex)
			FlagSpriteRenderer.color = new Color(0, 1, 0, 1);
	}
}
