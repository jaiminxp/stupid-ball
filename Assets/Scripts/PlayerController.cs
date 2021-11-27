using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	public float maxSpeed=10,moveForce,jumpForce,restartWait;
	public AudioClip jumpAudio,hitAudio;
	public Transform groundCheck;
	public GameManager gameManager;
	public GameObject deadPlayer;

	[HideInInspector] public bool dead,slicedOff,cutByKnife;
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public AudioSource audioSource;
	SpriteRenderer playerSpriteRenderer;
	Vector2 lineStart,lineEnd;
	GameObject temp;
	bool jump,grounded;
	float h;
	int layer;

	void Awake () 
	{
		rb = GetComponent<Rigidbody2D> ();
		layer = LayerMask.GetMask("Ground");
	}

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
		playerSpriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		dead = false;
	}

	void Update()
	{
		lineStart = new Vector2 (transform.position.x,transform.position.y);
		lineEnd = new Vector2 (groundCheck.position.x,groundCheck.position.y);
		grounded = Physics2D.Linecast (lineStart,lineEnd,layer);

		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			jump = true;
		}

		if (gameManager.index < gameManager.PlayerRespawnPoints.Length && Mathf.Round (transform.position.x) ==
			Mathf.Round (gameManager.PlayerRespawnPoints [gameManager.index].transform.position.x)) 
		{
			gameManager.index++;
			Debug.Log (gameManager.index);
		}

		if (gameManager.levelEnded)
		{
			rb.simulated = false;
		}
	}

	void FixedUpdate ()
	{
		Move ();
		if(jump)
		{
			Jump();
		}
	}
		
	void Move()
	{
		 h = Input.GetAxis ("Horizontal");

		if(Mathf.Abs(rb.velocity.x) < maxSpeed)
			rb.AddForce (new Vector2 (h * moveForce, 0));

		if (Mathf.Abs(rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector2(maxSpeed * Mathf.Sign(h),rb.velocity.y);
	}

	void Jump()
	{
		audioSource.clip = jumpAudio;
		audioSource.Play ();
		rb.AddForce (Vector2.up * jumpForce);
		jump = false;
	}
		
	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if ((other.CompareTag ("Hazard") || other.CompareTag("Knife")) && !dead) 
		{
			audioSource.clip = hitAudio;
			audioSource.Play ();
			if (other.CompareTag ("Knife")) 
			{
				cutByKnife = true;
			}
			else
				slicedOff = true;
			dead = true;
			temp = new GameObject();
			temp = Instantiate (deadPlayer,transform);
			playerSpriteRenderer.sprite = null;
			rb.simulated = false;
			yield return new WaitForSeconds (restartWait);
			gameManager.ActivateUIElements ();
		} 
		else if (other.CompareTag ("Boundary")) 
		{
			slicedOff = false;
			yield return new WaitForSeconds (restartWait);
			gameManager.ActivateUIElements ();
		}
	}
		
	public void DestroyDeadPlayer()
	{
		DestroyImmediate (temp);
	}	
}
