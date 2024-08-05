using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    public AudioSource birdFlapSource;
    public AudioClip birdFlapSFX;
    public AudioSource gameOverSource;
    public AudioClip gameOverSFX;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // sets reference to our logic manager's script component

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) { // makes sure game is not over to allow bird to flap
            myRigidbody.velocity = Vector2.up * flapStrength;
            birdFlapSource.clip = birdFlapSFX;
            birdFlapSource.Play();
        };

        if ((transform.position.y > 14.30 || transform.position.y < -14.30) && birdIsAlive) {
            gameOverSource.clip = gameOverSFX;
            gameOverSource.PlayOneShot(gameOverSFX);
            logic.gameOver();
            birdIsAlive = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) { // using OnCollision here instead of OnTrigger because this checking if bird collides with a solid object

        if (birdIsAlive)
        {
            gameOverSource.clip = gameOverSFX;
            gameOverSource.PlayOneShot(gameOverSFX);
            logic.gameOver();
            birdIsAlive = false;
        }
    }


}
