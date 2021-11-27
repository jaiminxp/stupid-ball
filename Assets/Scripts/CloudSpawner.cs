using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
	public GameObject[] cloudSet;
	public Transform UpLimit, DownLimit;
	public int maxSpawnWait,minSpawnWait,startWait,maxCloudsAtStart;
	int index,spawnWait;

	void Awake()
	{
		SpreadClouds ();
	}

	void Start ()
	{
		StartCoroutine (SpawnClouds());
	}

	IEnumerator SpawnClouds()
	{
		yield return new WaitForSeconds (startWait);
		for (;;) 
		{
			Vector3 spawnPosition = new Vector3 (Random.Range (UpLimit.position.x, DownLimit.position.x), Random.Range (UpLimit.position.y, DownLimit.position.y), 0);
			spawnWait = Random.Range (maxSpawnWait,minSpawnWait);

			index = Random.Range (0,cloudSet.Length);
			float tempScale = Random.value;
			GameObject tempCloud = Instantiate (cloudSet[index],transform);
			tempCloud.transform.position = spawnPosition;
			tempCloud.transform.localScale = new Vector3 (tempScale,tempScale,0f);

			yield return new WaitForSeconds (spawnWait);
		}
	}

	void SpreadClouds()
	{
		for (int i = 0;i<maxCloudsAtStart;i++) 
		{
			Vector3 spawnPosition = new Vector3 (Random.Range (UpLimit.position.x, DownLimit.position.x), Random.Range (UpLimit.position.y, DownLimit.position.y), 0);
			spawnWait = Random.Range (maxSpawnWait,minSpawnWait);

			index = Random.Range (0,cloudSet.Length);
			float tempScale = Random.value;
			GameObject tempCloud = Instantiate (cloudSet[index],transform);
			tempCloud.transform.position = spawnPosition;
			tempCloud.transform.localScale = new Vector3 (tempScale,tempScale,0f);
		}
	}
}
