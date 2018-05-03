using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnPickup : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] ok;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < ok.Length; i++)
        {


            GameObject Enemy = (GameObject)Instantiate(enemy, ok[i].transform.position, Quaternion.identity);
        }
    }
}
