using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPointAl : MonoBehaviour
{
    [SerializeField]
    private string tag;

    [SerializeField]
    private GameObject playerPrefab;
    private GameObject player;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private GameObject selectedSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        placePlayerRandomly();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
        }
    }
    private void placePlayerRandomly(){
        spawnPoints=GameObject.FindGameObjectsWithTag(tag);
        int rand = Random.Range(0,spawnPoints.Length);
        selectedSpawnPoint=spawnPoints[rand];
        player=Instantiate(playerPrefab,selectedSpawnPoint.transform.position, selectedSpawnPoint.transform.localRotation);

    }
}
