using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeed = 5f;
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += maxSpeed * Time.deltaTime;
        transform.position = pos;

        if (pos.y > 5.2 || pos.y < -5)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
