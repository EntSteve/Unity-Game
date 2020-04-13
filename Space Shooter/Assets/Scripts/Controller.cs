using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private HealthBar bar;
    public float maxSpeed = 3f;
    private float energy = 1f;
    public float decaySpeed = .5f;
    private bool horizontalMove;
    private bool verticalMove;
    private bool isLeft;
    private bool isUp;
    private bool shieldsEngaged;
 
    // Update is called once per frame
    void Update()
    {
        //Gives a Float from -1 to 1
        if(Input.GetAxis("Horizontal") != 0)
        {
            horizontalMove = true;
            verticalMove = false;
            if (Input.GetAxis("Horizontal") > 0)
            {
                isLeft = true;
            }
            else
            {
                isLeft = false;
            }
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            horizontalMove = false;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            verticalMove = true;
            horizontalMove = false;
            if (Input.GetAxis("Vertical") > 0)
            {
                isUp = true;
            }
            else
            {
                isUp = false;
            }
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            verticalMove = false;
        }
        //Toggles Between sheilds being on and off
        if (Input.GetButtonDown("Fire2"))
        {
            shieldsEngaged = !shieldsEngaged;
        }
    }

    // Update called once per tick
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (horizontalMove == true)
        {
            if (isLeft)
            {
                pos.x += maxSpeed * Time.deltaTime;
                if (pos.x > 9.5)
                {
                    pos.x = 9.5f;
                }
            }
            else
            {
                pos.x -= maxSpeed * Time.deltaTime;
                if (pos.x < -9.5)
                {
                    pos.x = -9.5f;
                }
            }
            transform.position = pos;
        }

        if (verticalMove == true)
        {
            if (isUp)
            {
                pos.y += maxSpeed * Time.deltaTime;
                if (pos.y > -2)
                {
                    pos.y = -2f;
                }
            }
            else
            {
                pos.y -= maxSpeed * Time.deltaTime;
                if (pos.y < -4.5)
                {
                    pos.y = -4.5f;
                }
            }
            transform.position = pos;
        }

        if (shieldsEngaged)
        {
            energy -=  .5f * Time.deltaTime;
            if (energy <= 0)
            {
                energy = 0;
                shieldsEngaged = false;
            }
            bar.updateEnergy(energy);
        }

        if (!shieldsEngaged)
        {
            energy += .5f * Time.deltaTime;
            if (energy >= 1)
            {
                energy = 1;
            }
            bar.updateEnergy(energy);
        }
    }
}
