using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLateral : MonoBehaviour
{
    public float speed =  7f;
    private float destroyLimR = 25f;
    private float destroyLimL = -25f;
    public PlayerController playerControllerScript;
       
    void Start()
    {playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();}
            void Update()
    {
            if (!playerControllerScript.gameOver)
            { transform.Translate(Vector3.right * speed * Time.deltaTime); }

            else { Destroy(gameObject); }

            if (transform.position.x <= destroyLimL || transform.position.x >= destroyLimR)
            { Destroy(gameObject); }
    }
}
