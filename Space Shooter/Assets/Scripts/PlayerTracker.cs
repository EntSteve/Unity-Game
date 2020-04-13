using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    private Transform trackingPlayer;
    private bool goingRight;
    public float delay = .5f;
    private float coolDown = 0;
    private Vector3 playerShip;
    // Start is called before the first frame update
    void Start()
    {
        findPlayerObject();
    }

    void FixedUpdate()
    {
        coolDown -= delay;
        if (coolDown < 0)
        {
            coolDown = 5;
            if (trackingPlayer == null)
            {
                return;
            }
            Vector3 pos = transform.position;
            playerShip = trackingPlayer.position;

            if (playerShip.x > pos.x)
            {
                goingRight = true;
            }
            else if (playerShip.x < pos.x)
            {
                goingRight = false;
            }

            //Go Right
            if (goingRight)
            {
                pos.x += .3f;
            }

            //Go Left
            if (!goingRight)
            {
                pos.x -= .3f;
            }
            transform.position = pos;
        }
    }

    private void findPlayerObject()
    {
        //Get the player as a GameObject then the transform out of the GameObject
        GameObject player = GameObject.Find("PlayerShip");
        trackingPlayer = player.transform;
    }
}
