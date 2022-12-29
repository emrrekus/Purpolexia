using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDiaamond : MonoBehaviour
{
    
    public Animator Animatorr;


    private void Start()
    {
        Animatorr = GetComponent<Animator>();    
    }

    void Update()
    {
        if (PlayerInteraction.finallyy)
        {
            Animatorr.SetTrigger("Finally");
        }
    }
}
