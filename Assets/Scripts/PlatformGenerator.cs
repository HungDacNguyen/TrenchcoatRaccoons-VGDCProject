﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    //Platform Generation
    public GameObject thePlatform;
    public GameObject theFloatingPlatform;
    public Transform generationPoint;
    public GameObject bird;
    public GameObject cat;

    private float platformWidth;

    //Enenmy Generation
    private EnenmyGenerator theEnenmyGenerator;

    // Use this for initialization
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        theEnenmyGenerator = FindObjectOfType<EnenmyGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {   
            //Variables
            float distanceBetweenChance = Random.Range(0, 2);
            float floatingPlatform = Random.Range(0, 2);
            int distanceBetween = 0;

            //One out of 2 chance will there be a hole in the floor
            if (distanceBetweenChance == 0)
            {
                distanceBetween = 2;
            }

            //Floor Platform, distancebetween will vary due to random distance chance
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            Instantiate(thePlatform, transform.position, transform.rotation);

            //Random floating platforms 2/3 chance
            if (floatingPlatform == 0)
            {
                int randomHeight = Random.Range(3, 8);
                int randomWidth = Random.Range(2, 4);
                //50%50 chance an enenmy will spawn or a floating platform will spawn
                int randomChance = Random.Range(0, 2);
                if (randomChance == 1)
                {
                    Vector3 tempPosition = new Vector3(transform.position.x + (theFloatingPlatform.GetComponent<BoxCollider2D>().size.x * 2) + randomWidth, transform.position.y + randomHeight, transform.position.z);
                    Instantiate(theFloatingPlatform, tempPosition, transform.rotation);
                }
                else
                {
                    int randomEnenmy = Random.Range(0, 2);
                    string enemy = "";
                    // 50% chance a bird will spawn or 50% chance a cat will spawn
                    if (randomEnenmy == 1)
                    {
                        Vector3 tempPosition = new Vector3(transform.position.x + (bird.GetComponent<BoxCollider2D>().size.x * 2) + randomWidth - 8, transform.position.y + randomHeight + 1, transform.position.z);
                        enemy = "bird";
                        theEnenmyGenerator.SpawnEnenmy(tempPosition, enemy);
                    }
                    else
                    {
                        Vector3 tempPosition = new Vector3(transform.position.x + (cat.GetComponent<BoxCollider2D>().size.x * 2) + randomWidth + 7, transform.position.y + randomHeight, transform.position.z);
                        enemy = "cat";
                        theEnenmyGenerator.SpawnEnenmy(tempPosition, enemy);
                    }
                }
            }
        }
    }
}
