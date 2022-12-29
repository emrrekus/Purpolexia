using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stags : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInteraction.level2Succes)
        {
            gameObject.SetActive(false);
        }
       

    }


    
}
