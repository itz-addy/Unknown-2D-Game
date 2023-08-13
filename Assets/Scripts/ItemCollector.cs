using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherryCount = 0;
    [SerializeField] public Text cherriesText;
    [SerializeField] private AudioSource cherrySound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            cherrySound.Play();
            Destroy(collision.gameObject);
            cherryCount++;
            cherriesText.text = "Cherries: " + cherryCount;
        }
    }
}
