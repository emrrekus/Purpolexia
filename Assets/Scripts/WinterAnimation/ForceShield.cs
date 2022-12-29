using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceShield : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (PlayerInteraction.level3Succes)
        {
            gameObject.SetActive(false);
        }
    }
}
