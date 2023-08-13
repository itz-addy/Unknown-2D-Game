using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(characterPrefabs[selectedCharacter], spawnPoint.position, Quaternion.identity);
        Camera.main.GetComponent<CameraController>().player = clone.transform;
        ItemCollector ic = clone.GetComponent<ItemCollector>();
        ic.cherriesText = GameObject.Find("Cherries Text").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
