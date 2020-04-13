using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    bool isShooting = false;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;

        }
    }

    private void FixedUpdate()
    {
        cooldownTimer -= Time.deltaTime;
        if (isShooting && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
            Instantiate(bulletPrefab,transform.position, transform.rotation);
        }
    }
}
