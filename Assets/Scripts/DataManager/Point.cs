using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Point : MonoBehaviour
{
    public static Point Instance;
    public static int iceStone;
    public static int forestStone;
    public GameObject questUI;
    bool isQuest = false;
    public static bool isActiveWater = false;
    public static bool isActivePlant = false;
    public static int finish=0;
    public static int finish1=0;

    public TMP_Text wheelText;
    public static event Action finishTrigger; 
    


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isQuest = !isQuest;
            questUI.SetActive(isQuest);
        }
        if (finish+finish1==2)
        {
            finishTrigger?.Invoke();
        }
        
    }



}
