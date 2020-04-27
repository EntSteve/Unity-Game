using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    private Transform trackingPlayer;
    private bool goingRight;
    public float delay = 0.5f;
    private float coolDown = 0;
    public float lossPlayerTime = 1;
    private Vector3 playerShip;
    public bool hasTarget = false;
    [SerializeField] float shipSpeed = .3f;
    private List<GameObject> otherShips;
    // Start is called before the first frame update
    void Start()
    {
        findPlayerObject();
        otherShips = new List<GameObject>();
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
            coolDown = 5f;
            trackOtherShips();

            if (trackingPlayer == null) // Player is dead
            {
                return;
            }

            //make a modifable version of the objects location before commiting the movement chage
            Vector3 pos = transform.position;
            playerShip = trackingPlayer.position;

            if (!ShipComunicationNetwork.seePlayer)
            { //Ship idle patrolling
              //Ship goes left until it hits the left boundry -5f
                if (pos.x < -5.0f)
                {//Go right until pos is > 5
                    goingRight = true;
                }
                if (pos.x > 5.0f)
                {
                    goingRight = false;
                }
            }
            if (ShipComunicationNetwork.seePlayer)
            {//Tracking the 
                if (ShipComunicationNetwork.lastPlayerLocation.x > pos.x)
                {
                    goingRight = true;
                }
                else if (ShipComunicationNetwork.lastPlayerLocation.x < pos.x)
                {
                    goingRight = false;
                }
            }

            //This section runs regarless of if it does or does not have a target
            //Go Right
            if (goingRight)
            {
                pos.x += shipSpeed;
                //Check for collusion

                foreach (GameObject ship in otherShips)
                {
                    float tempLocation = 0;
                    try
                    {
                        tempLocation = ship.transform.position.x;
                    }
                    catch
                    {//Otehr ship was destroyed
                        otherShips.Remove(ship);
                        break;
                    }
                    if (pos.x > tempLocation - 1f && pos.x < tempLocation) //This part needs figured out&& tempLocation < pos.x + shipSpeed
                    {
                        pos.x -= shipSpeed;//Makes it so it deosn't move
                        goingRight = false;
                        break;
                    }
                }
            }

            //Go Left
            if (!goingRight)
            {
                pos.x -= shipSpeed;
                foreach (GameObject ship in otherShips)
                {
                    float tempLocation = 0f;
                    try
                    {
                        tempLocation = ship.transform.position.x;
                    }
                    catch
                    {//Oterh ship was destroyed
                        otherShips.Remove(ship);
                        break;
                    }

                    if (pos.x < tempLocation + 1f && pos.x > tempLocation ) //This part needs figured out
                    {
                        pos.x += shipSpeed; //Makes it so it doesn't move
                        goingRight = true;
                        break;
                    }
                }
            }
            transform.position = pos;
        }

        //If the player ship is in range
        if (Mathf.Abs(transform.position.x - playerShip.x) <= 0.25f)// || Mathf.Abs( transform.position.x - playerShip.x )>= 0.1)
        {
            Debug.Log("Player is being tracked");
            hasTarget = true;
            ShipComunicationNetwork.seePlayer = true;
            ShipComunicationNetwork.lastPlayerLocation = playerShip;
            lossPlayerTime = 3;
        }
        //Timer to lose the player
        lossPlayerTime -= Time.deltaTime;
        if (lossPlayerTime < 0)
        {
            Debug.Log("Player is NOT being tracked");
            hasTarget = false;
            ShipComunicationNetwork.seePlayer = false;
        }
    }

    //ToDo make this be called when a ship is made or destroyed in the future
    private void trackOtherShips()
    {
        string currentShipType = this.tag;
        /* switch(currentShipType){
             case "Enemy": 
                 otherShipsReturn = GameObject.FindGameObjectsWithTag("Enemy");
                 Debug.Log(otherShipsReturn.Length + " Type 1 Ships found");
                 break;
             case "Enemy2":
                 otherShipsReturn = GameObject.FindGameObjectsWithTag("Enemy2");
                 Debug.Log(otherShipsReturn.Length + " Type 2 Ships found");
                 break;
             case "Enemy3":
                 otherShipsReturn = GameObject.FindGameObjectsWithTag("Enemy3");
                 Debug.Log(otherShipsReturn.Length + " Type 3 Ships found");
                 break;
         }*/
        //Finds all ships of the same tag and adds them to the list to be be used again later
        foreach (GameObject ship in GameObject.FindGameObjectsWithTag(currentShipType))
        {
            if (ship == this.gameObject)
            { //Skips adding the 
                continue;
            }
            else if (ship == null)
            {
                continue;
            }
            otherShips.Add(ship);
        }
    }
    private void findPlayerObject()
    {
        //Get the player as a GameObject then the transform out of the GameObject
        GameObject player = GameObject.Find("PlayerShip");
        if (player == null)
        {
            player = new GameObject();
        }
        trackingPlayer = player.transform;
    }
}
