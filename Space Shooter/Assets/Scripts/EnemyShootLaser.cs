using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootLaser : MonoBehaviour
{
    public GameObject LaserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 laserOffset;
        laserOffset = new Vector3(transform.position.x, transform.position.y - 1.7f);
        Instantiate(LaserPrefab, laserOffset, transform.rotation);
    }

    void fireingLaser(){
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
