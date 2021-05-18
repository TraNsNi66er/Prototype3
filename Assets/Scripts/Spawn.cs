using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obstaclePrefab ;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float srtartDelay = 2;
    private float repeatRate = 2 ; 
    private PlayetController playetControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle",srtartDelay,repeatRate);
        playetControllerScript = GameObject.Find("Player").GetComponent<PlayetController>();
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if(playetControllerScript.gameOver==false)
        {
        Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);
        }
        
    }
}
