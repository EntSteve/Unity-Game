using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject playerPrfab;
    GameObject playerInstance;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
        delay = 2;
        playerInstance = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {

        GameObject.Find("PlayerShip");
        if (playerInstance == null){
            delay -= Time.deltaTime;
            if (delay < 0){
                delay = 2;
                playerInstance = Instantiate(playerPrfab,transform.position,transform.rotation);
            }
        }
        
    }
}
