using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightEnemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float targetDistance;

    // Start is called before the first frame update
    void Start()
    {
        // target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > targetDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);   
        }
    }
}
