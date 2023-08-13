using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // int attack = 0;
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Attack");
            anim.SetTrigger("attack");
            // attack = 1;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Attack 2");
            anim.SetTrigger("attack2");
            // attack = 0;
        }
        
    }
}
