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
    public bool hasTarget = false;
    [SerializeField] float shipSpeed;
    // Start is called before the first frame update
    void Start()
    {
        findPlayerObject();
    }
    public bool getHasTarget()
    {
        return hasTarget;
    }
    public float getPlayerY()
    {
        return playerShip.x;
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

            if (!hasTarget){ //Ship idle patrolling
            //Ship goes left until it hits the left boundry -5f
                if (pos.x < -5.0f ){//Go right until pos is > 5
                    goingRight = true;
                }
                if (pos.x > 5.0f){
                    goingRight = false;
                }
            }
            if (hasTarget){//Tracking the player
                if (playerShip.x > pos.x)
                {
                    goingRight = true;
                }
                else if (playerShip.x < pos.x)
                {
                    goingRight = false;
                }
            }
             
            //This section runs regarless of if it does or does not have a target
            //Go Right
            if (goingRight)
            {
                pos.x += shipSpeed;
            }

            //Go Left
            if (!goingRight)
            {
                pos.x -= shipSpeed;
            }
            transform.position = pos;
        }
        //If the player ship is in range
        if(Mathf.Abs( transform.position.x - playerShip.x) <= 0.25f)// || Mathf.Abs( transform.position.x - playerShip.x )>= 0.1)
        {
            hasTarget = true;
        }
        else
        {
            hasTarget = false;
        }
    }

    private void findPlayerObject()
    {
        //Get the player as a GameObject then the transform out of the GameObject
        GameObject player = GameObject.Find("PlayerShip");
        trackingPlayer = player.transform;
    }
}
