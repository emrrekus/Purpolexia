using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator Lvl1RAnimator;

    public AudioClip audioClip;
    public AudioSource AudioSource;


    private void Start()
    {
        Lvl1RAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerInteraction.level1Succes)
        {
            Lvl1RAnimator.SetTrigger("Lvl1Left");
            Lvl1RAnimator.SetTrigger("Lvl1Right");
            

        }
        if (PlayerInteraction.level2Succes)
        {
            Lvl1RAnimator.SetTrigger("Lvl2Left");
            Lvl1RAnimator.SetTrigger("Lvl2Right");

        }
    }

}
