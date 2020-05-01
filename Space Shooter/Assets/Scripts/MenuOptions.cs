using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
          //Exits the application
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("Button Pressed");
        }
    }
}
