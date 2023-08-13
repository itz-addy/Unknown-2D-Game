using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Settings")]
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header ("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;


    [Header ("Enemy Animator")]
    [SerializeField] private Animator anim;



    private void Awake()
    {
        initScale = enemy.localScale;
        
    }
    private void Update()
    {
        if(enemy != null)
        {
            if(movingLeft)
            {
                if(enemy.position.x >= leftPoint.position.x)
                    MoveInDirection(-1);
                else
                {
                    ChangeDirection();
                }
            }
            else
            {
                if(enemy.position.x <= rightPoint.position.x)
                    MoveInDirection(1);
                else
                {
                    ChangeDirection();
                }
            }
        }
    }

    private void ChangeDirection()
    {
        anim.SetBool("walk", false);

        idleTimer += Time.deltaTime;

        if(idleTimer >= idleDuration)
        {
            movingLeft = !movingLeft;

        }
    }

    private void MoveInDirection(int _direction)
    {   
        idleTimer = 0f;
        anim.SetBool("walk", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
        initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction *speed, 
        enemy.position.y, enemy.position.z);
    }

    void OnDisable()
    {
        if(enemy != null)
        {
            anim.SetBool("walk", false);
        }
    }
}
