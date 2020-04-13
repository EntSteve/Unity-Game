using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private HealthBar energy;

    bool isShooting = false;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    float currentEnergy;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            currentEnergy = energy.getCurrentPercent();
            if (currentEnergy > 0)
            {
                isShooting = true;
            }            
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
            currentEnergy -= .8f;
            energy.updateEnergy(currentEnergy);
        }
    }
}
