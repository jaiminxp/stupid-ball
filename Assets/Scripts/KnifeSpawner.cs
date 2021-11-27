using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
	public GameObject knife;
	public float spawnWait,waveWait;
	public int knivesPerWave,wavesCount;

	void Start () 
	{
		StartCoroutine ("Spawn");
	}

	IEnumerator Spawn()
	{
		for (int i = 0; i < wavesCount; i++) 
		{
			for (int j = 0; j < knivesPerWave; j++) 
			{
				Instantiate (knife, transform);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
