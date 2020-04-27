using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Ship1Prefab;
    [SerializeField] private GameObject Ship2Prefab;
    [SerializeField] private GameObject Ship3Prefab;
    Vector3 pos;
    private GameObject[] type1Ships;
    private GameObject[] type2Ships;
    private GameObject[] type3Ships;
    private float delay = 5f;
    public bool spawnerOn;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerOn)
        {
            delay -= Time.deltaTime;
            //Add a cooldown
            if (delay < 0)
            {
                delay = 5f;
                //Add a enemy untill there are three of each type
                FindShips();
                //Finds the three types of ships and generate till there are three of each ship
                int shipLimit = 3;
                // Debug.Log("Number of Type One Ships " + type1Ships.Length);
                if (type1Ships.Length < shipLimit)
                {
                    SpawnType1Ship();
                }
                //Debug.Log("Number of Type Two Ships " + type2Ships.Length);
                if (type2Ships.Length < shipLimit)
                {
                    SpawnType2Ship();
                }
                //  Debug.Log("Number of Type Three Ships " + type3Ships.Length);
                if (type3Ships.Length < shipLimit)
                {
                    SpwanType3Ship();
                }
            }
        }
    }

    private void FindShips()
    {
        type1Ships = GameObject.FindGameObjectsWithTag("Enemy");
        type2Ships = GameObject.FindGameObjectsWithTag("Enemy2");
        type3Ships = GameObject.FindGameObjectsWithTag("Enemy3");
    }

    private void SpawnType1Ship()
    {
        pos.x = 4f;
        pos.y = 1.5f;
        pos.z = -1;
        Instantiate(Ship1Prefab, pos, transform.rotation);
    }

    private void SpawnType2Ship()
    {
        pos.x = 4f;
        pos.y = 2.5f;
        pos.z = -1;
        Instantiate(Ship2Prefab, pos, transform.rotation);
    }

    private void SpwanType3Ship()
    {
        pos.x = 4f;
        pos.y = 3.5f;
        pos.z = -1;
        Instantiate(Ship3Prefab, pos, transform.rotation);
    }
}
