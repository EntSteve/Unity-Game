using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private float currentPercent;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    public void updateEnergy(float percent)
    {
        currentPercent = percent;
        bar.localScale = new Vector3(currentPercent, 1);
    }

    public float getCurrentPercent()
    {
        return currentPercent;
    }


}
