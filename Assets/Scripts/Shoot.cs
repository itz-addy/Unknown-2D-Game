using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(sr.flipX == false)
            {
                Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            }
            else
            {
                Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0, 0, 180));
            }
            //Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}
