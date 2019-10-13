using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float speed = 10f;
    [SerializeField] AudioClip[] ballSounds;
    bool hasStarted = false;
    // Start is called before the first frame update
    Vector2 paddleToBallVector;
    float paddleToBallCompareX;
    AudioSource bounceAudio;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        bounceAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted == false)
        {
            lockBallToPaddle();
            launchBall();
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle" && hasStarted == true)
        {
            checkBounceAngle();
        }   
    }
    private void checkBounceAngle()
    {
        paddleToBallCompareX = transform.position.x - paddle1.transform.position.x;        
        
        if (paddleToBallCompareX < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed*paddleToBallCompareX, speed);
        }
        else if (paddleToBallCompareX > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed*paddleToBallCompareX, speed);
        }
    }

    private void launchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
        }
    }

    private void lockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
