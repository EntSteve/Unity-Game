using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    public void updateEnergy(float percent)
    {
        bar.localScale = new Vector3(percent, 1);
    }


}
