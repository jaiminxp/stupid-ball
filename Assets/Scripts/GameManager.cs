using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Transform[] PlayerRespawnPoints;
	public PlayerController plCtr;
	public GameObject player;
	public Text gameOverText;
	public Button ReloadCheckpoint_Button, RestartLevel_Button, QuitGame_Button, ResumeGame_Button, pauseGame_Button;
	public Sprite playerSprite;
	public Image Backgroud, slicedOff, OutOfBounds, KnifedOff, PauseMenuImage;
	public Color BgColor = new Color(0, 0, 0, 1f);
	public int index;
	public AudioClip clickAudio;

	[HideInInspector] public bool levelEnded;

	bool paused;
	SpriteRenderer playerSpriteRenderer;
	Rigidbody2D rb2D;

	void Awake()
	{
		index = 0;
		rb2D = player.GetComponent<Rigidbody2D>();
		DeactivateUIElements();
		paused = false;
	}

	void Start()
	{
		playerSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
	}

	void Update()
	{
		if (levelEnded)
			ShowFinalMenu();
	}

	public void RespawnPlayer()
	{
		DeactivateUIElements();
		playerReady();
		player.transform.position = PlayerRespawnPoints[index - 1].transform.position;
		rb2D.velocity = Vector2.zero;
		plCtr.dead = false;
	}

	public void ReloadLevel()
	{
		SceneManager.LoadScene("Level0");
	}

	void DeactivateUIElements()
	{
		slicedOff.enabled = false;
		OutOfBounds.enabled = false;
		KnifedOff.enabled = false;
		PauseMenuImage.enabled = false;
		plCtr.cutByKnife = false;

		gameOverText.text = "";
		Backgroud.color = Color.clear;

		ReloadCheckpoint_Button.gameObject.SetActive(false);
		RestartLevel_Button.gameObject.SetActive(false);
		QuitGame_Button.gameObject.SetActive(false);
		ResumeGame_Button.gameObject.SetActive(false);
	}

	public void ActivateUIElements()
	{
		if (paused)
		{
			ResumeGame_Button.gameObject.SetActive(true);
			PauseMenuImage.enabled = true;
			gameOverText.text = "PAUSED";
		}
		else if (plCtr.cutByKnife)
		{
			KnifedOff.enabled = true;
			gameOverText.text = "Sliced Off !!";
		}
		else if (plCtr.slicedOff)
		{
			slicedOff.enabled = true;
			gameOverText.text = "Sliced Off !!";
		}
		else
		{
			OutOfBounds.enabled = true;
			gameOverText.text = "Out Of Bounds !!";
		}

		Backgroud.color = BgColor;
		RestartLevel_Button.gameObject.SetActive(true);
		QuitGame_Button.gameObject.SetActive(true);

		if (index <= 1)
		{
			ReloadCheckpoint_Button.gameObject.SetActive(true);
			ReloadCheckpoint_Button.interactable = false;
		}

		else
		{
			ReloadCheckpoint_Button.interactable = true;
			ReloadCheckpoint_Button.gameObject.SetActive(true);
		}
	}

	void playerReady()
	{
		playerSpriteRenderer.sprite = playerSprite;
		rb2D.simulated = true;
	}

	public void PauseGame()
	{
		paused = true;
		Time.timeScale = 0;
		ActivateUIElements();
	}

	public void ResumeGame()
	{
		paused = false;
		Time.timeScale = 1;
		DeactivateUIElements();
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void ShowFinalMenu()
	{
		Backgroud.color = BgColor;
		gameOverText.text = "Level 1 Complete !";
		pauseGame_Button.gameObject.SetActive(false);
		RestartLevel_Button.gameObject.SetActive(true);
		QuitGame_Button.gameObject.SetActive(true);
	}

	public void ClickSound()
	{
		plCtr.audioSource.clip = clickAudio;
		plCtr.audioSource.Play();
	}
}
