using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
	public void StartTheGame()
	{
		SceneManager.LoadScene("Level0");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
