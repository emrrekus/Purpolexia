using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject portal1;
    [SerializeField] GameObject portal2;

    private void Start()
    {
        portal1.SetActive(false);
        portal2.SetActive(false);
    }
    void Update()
    {
        if (PlayerInteraction.finallyy)
        {

           portal1.SetActive(true);
            portal2.SetActive(true);
        }
    }
}
