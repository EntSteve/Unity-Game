using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public float MoveSpeed = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.y -= MoveSpeed * Time.deltaTime;

        transform.position = pos;

        if (pos.y < -10)
        {
            pos.y = 18.5f;
            transform.position = pos;
        }
    }
}
