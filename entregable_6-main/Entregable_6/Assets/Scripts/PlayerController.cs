using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    public float jumpForce = 5f;
    public float gravityMod = 1f;
    private float limY = 14f;
    public bool isOnGround = true;
    public bool gameOver = false;
    private AudioSource playerAudio;
    public AudioClip jumpClip;
    public AudioClip colisionClip;
    public ParticleSystem particlesExplosion;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && transform.position.y < limY)
        {
            playerAudio.PlayOneShot(jumpClip, 1);
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    }
        if (transform.position.y >= limY)
        { transform.position = new Vector3(transform.position.x, limY, transform.position.z); } 
    }
          public void OnCollisionEnter(Collision otherCollider)
    {         if (!gameOver)
          {
            if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("GAME OVER");
                playerAudio.PlayOneShot(colisionClip, 1);
                Instantiate(particlesExplosion, gameObject.transform.position, gameObject.transform.rotation);
                gameOver = true;
                Destroy(gameObject);
                playerAudio.Stop();
            }
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                Debug.Log("GAME OVER");
                gameOver = true;
                Destroy(gameObject);
            }
          }
    }
}
