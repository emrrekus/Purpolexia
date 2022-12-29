using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{

    

    public static bool level1Succes = false;

    public static bool level2Succes = false;
    public static bool level3Succes = false;
    public static bool finallyy = false;

    public static event Action<int> icePortalTrigger;
    public static event Action<int> forestPortalTrigger;

    public static event Action<bool> iceStonePut;
    public static event Action<bool> forestStonePut;

  


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "IceWorld")
        {
            icePortalTrigger?.Invoke(0);
            SceneManager.LoadScene("SampleScene");
        }
        else if (other.tag == "ForestWorld")
        {
            forestPortalTrigger?.Invoke(0);
            SceneManager.LoadScene("Forest1");
        }
        else if (other.tag == "MainWorld" && Point.iceStone == 1)
        {
            icePortalTrigger?.Invoke(2);
            SceneManager.LoadScene("MainMap");
        }
        else if (other.tag == "MainWorld1" && Point.forestStone == 1)
        {
            forestPortalTrigger?.Invoke(3);
            SceneManager.LoadScene("MainMap");
        }

        if (other.tag == "IceStonePut" && Input.GetKeyDown(KeyCode.E) && Point.iceStone == 1)
        {
            icePortalTrigger?.Invoke(3);
            Point.isActiveWater = true;
            iceStonePut?.Invoke(true);
            Point.finish = 1;
            
        }
        if (other.tag == "ForestStonePut" && Input.GetKeyDown(KeyCode.E) && Point.forestStone == 1)
        {
            forestPortalTrigger?.Invoke(4);
            Point.isActivePlant = true;
            forestStonePut?.Invoke(true);
            Point.finish1 = 1;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Level1")
        {
            Debug.Log("Level1 Complate");
            level1Succes = true;
        }
        if (other.tag == "Level2")
        {
            Debug.Log("Level2 Complate");
            level2Succes = true;
        }
        if (other.tag == "Level3")
        {
            Debug.Log("Level3 Complate");
            level3Succes = true;
        }
        if (other.tag == "Finally")
        {
            Debug.Log("Finally");
            finallyy = true;
        }
    }


}

