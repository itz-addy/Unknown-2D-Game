using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private Animator anim;
    // private bool isShot = false;
    // private GameObject player;
    private float timeRemaining;
    private bool timerIsRunning = false;
    private bool countdownStart = false;
    public bool isMoving;
    private Rigidbody2D playerRb;
    private Rigidbody2D rb;
    private float jumpForce = 10f;
    private SpriteRenderer spriteRenderer;
    private int currentWaypointIndex = 0;
    
    [SerializeField] private float speed = 2f;

    private enum AnimationState
    {
        walk, snow1, snow2, snow3, snow4, snow5
    }
        AnimationState state;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {   
        if (countdownStart == true)
        {
            if (timeRemaining > 0)
            {
                timerIsRunning = true;
                timeRemaining -= Time.deltaTime;
                Debug.Log("Time started!" + timeRemaining + "TimerIsRunning = " + timerIsRunning);
            }
                else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Debug.Log("Time has run out! TimerIsRunning = " + timerIsRunning);
                
                if(state == AnimationState.snow3)
                {
                    timeRemaining = 1f;
                    anim.SetInteger("state", 2);
                    // isMoving = false;
                    a -=1;
                    state = AnimationState.snow2;
                }

                else if(state == AnimationState.snow2)
                {
                    timeRemaining = 1f;

                    anim.SetInteger("state", 1);
                    // isMoving = false;
                    a -=1;
                    state = AnimationState.snow1;
                    
                }

                else if(state == AnimationState.snow1)
                {
                    anim.SetInteger("state", 0);
                    isMoving = false;
                    a -=1;
                    state = AnimationState.walk;
                    countdownStart = false;
                }       
                              
            }
        
        }

        if(isMoving == false)
        {
            if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                spriteRenderer.flipX = false;

                if(currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                    spriteRenderer.flipX = true;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); 
        }
    }

    int a = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            anim.SetTrigger("enemy_death");
        }

        else if (collision.gameObject.CompareTag("Bullet") && a == 0)
        {
            isMoving = true;
            a++;
            timeRemaining = 1f;
            countdownStart = true;
            state = AnimationState.snow1;
        }

        else if (collision.gameObject.CompareTag("Bullet") && a == 1)
        {
            isMoving = true;
            timeRemaining = 1f;
            a++;
            state = AnimationState.snow2;
            countdownStart = true;
        }

        else if (collision.gameObject.CompareTag("Bullet") && a == 2)
        {
            isMoving = true;
            timeRemaining = 1f;
            a++;
            state = AnimationState.snow3;
            countdownStart = true;
                        
            
        }

        else if (collision.gameObject.CompareTag("Bullet") && a == 3)
        {
            isMoving = true;
            a++;
            state = AnimationState.snow4;
            
        }

        else if (collision.gameObject.CompareTag("Bullet") && a == 4)
        {
            isMoving = true;
            state = AnimationState.snow5;
            GetComponent<BoxCollider2D>().enabled = false;
            // Die();
        }

        anim.SetInteger("state", (int)state);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(GetComponent<Enemy>().enabled == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if(!spriteRenderer.flipX)
                {
                    spriteRenderer.flipX = true;
                    currentWaypointIndex--;
                }
                else    
                {
                    spriteRenderer.flipX = false;
                    currentWaypointIndex++;
                }
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);   
    }
}
