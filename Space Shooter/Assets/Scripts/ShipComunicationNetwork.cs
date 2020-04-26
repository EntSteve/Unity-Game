using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ShipComunicationNetwork
{//Tracks if any ship sees the plyer
    public static bool seePlayer = false;
    public static Vector3 lastPlayerLocation;

    /*
    public void setSeePlayer(bool seePlayerPass){
        seePlayer = seePlayerPass; 
    }

    public bool getSeePlayer(){
        return seePlayer;
    }

    public void setLastPlayerLocation(Vector3 loc){
        lastPlayerLocation = loc;
    }

    public Vector3 getLastPlayerLocation(){
        return lastPlayerLocation;
    }*/
}
