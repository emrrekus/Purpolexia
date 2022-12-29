using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] astreoidPrefab;
    private Vector3 spawnPos;





    private void Start()
    {
       

        InvokeRepeating("AstreoidSpawner", 3, 5);

    }

    void AstreoidSpawner()
    {

        spawnPos = new Vector3(Random.Range(50, 80), Random.Range(10, 35), Random.Range(57, 80));

        if (PlayerInteraction.level2Succes && !PlayerInteraction.level3Succes)
        {
            for (int i = 0; i < astreoidPrefab.Length; i++)
            {


                Instantiate(astreoidPrefab[i], spawnPos, Quaternion.identity);


            }

        }
        



    }



}

