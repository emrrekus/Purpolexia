using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static event Action<int> iceStonePicked;
    public static event Action<int> forestStonePicked;
   
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "IceStone" && Input.GetKeyDown(KeyCode.E))
        {
            if (Point.iceStone == 0)
                Point.iceStone++;
            
            iceStonePicked?.Invoke(1);
           
            GameObject iceStone=GameObject.FindGameObjectWithTag("Water");
           iceStone.SetActive(false);

        }
        if (other.tag == "ForestStone" && Input.GetKeyDown(KeyCode.E))
        {
            if (Point.forestStone == 0)
                Point.forestStone++;
           
            forestStonePicked?.Invoke(2);
            GameObject stone = GameObject.FindGameObjectWithTag("ForestStone");
            stone.SetActive(false);
        }
    }

  
}
