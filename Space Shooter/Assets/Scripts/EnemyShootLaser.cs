using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootLaser : MonoBehaviour
{
    [SerializeField] GameObject LaserPrefab;
    public float shootDelay = 0.25f;
    float cooldownTimer = 0;

    private Vector3 laserOffset;



    // Start is called before the first frame update
    void Start()
    {

        //Instantiate(LaserPrefab, laserOffset, transform.rotation);
    }

    void fireingLaser()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0 && GameObject.Find("enemy2").GetComponent<PlayerTracker>().hasTarget)
        {
            cooldownTimer += shootDelay;
            laserOffset = new Vector3(transform.position.x, transform.position.y - .1f); //Spawning in front of ship
            Instantiate(LaserPrefab, laserOffset, transform.rotation);
        }
    }
}
