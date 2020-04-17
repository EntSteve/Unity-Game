using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBullet : MonoBehaviour
{
    [SerializeField] GameObject EnemyShoot;

    public float shootDelay = 0.25f;
    float cooldownTimer = 0;
    private Vector3 offset;


    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0 && GameObject.Find("enemy1").GetComponent<PlayerTracker>().hasTarget)
        {
            cooldownTimer += shootDelay;
            offset = new Vector3(transform.position.x, transform.position.y - .5f); //Spawning in front of ship
            Instantiate(EnemyShoot, offset, transform.rotation);
        }
    }
}
