using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AppleDrop : MonoBehaviour
{
    public GameObject appleD;
    public float dropRate = 2;
    private float timer = 0;
    public float heightOffset = 10; 

    // Start is called before the first frame update
    void Start()
    {
        spawnApple();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < dropRate)
        { 
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnApple();
            timer = 0;
        }
    }
    void spawnApple()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float hightPoint = transform.position.y + heightOffset;

            Instantiate(appleD, new Vector3(transform.position.x, Random.Range(lowestPoint, hightPoint), 0), transform.rotation);
    }
}