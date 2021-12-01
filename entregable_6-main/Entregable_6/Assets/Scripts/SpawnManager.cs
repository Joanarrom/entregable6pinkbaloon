using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float repeatRate = 5f;
    private float startDelay = 1f;
 
    public int left = 0;
    public int right = 1;
   
    private Quaternion roffset = Quaternion.Euler(0, 180, 0);
    private Vector3 spawnPos;
  
    public PlayerController playerControllerScript;
    public float ranX;
    private float ranY;
    
    void Start()
    {
        InvokeRepeating("Spawner", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }         
    private void Spawner()
    {
        if (!playerControllerScript.gameOver)
        {      
            ranY = Random.Range(3, 15);
            ranX = Random.Range(0, 3);
                        if (ranX == left)
            {
                spawnPos = new Vector3(-15, ranY, 0);
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);  
            }             
             if (ranX == right)
            {
                spawnPos = new Vector3(15, ranY, 0);
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation * roffset);
            }
         }
        }

    }

