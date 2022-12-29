using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public GameObject[] linesRight;
    public GameObject[] linesLeft;

    private void OnEnable()
    {
        Player.iceStonePicked += AquaQuestTagUpdate;
        PlayerInteraction.icePortalTrigger += AquaQuestTagUpdate;
        PlayerInteraction.forestPortalTrigger += PlantQuestTagUpdate;
        OpenDoor.frostStonee += PlantQuestTagUpdate;
        Player.forestStonePicked += PlantQuestTagUpdate;
       

    } 
    private void OnDisable()
    {
        Player.iceStonePicked -= AquaQuestTagUpdate;
        PlayerInteraction.icePortalTrigger -= AquaQuestTagUpdate;
        PlayerInteraction.forestPortalTrigger -= PlantQuestTagUpdate;
        OpenDoor.frostStonee -= PlantQuestTagUpdate;
        Player.forestStonePicked += PlantQuestTagUpdate;
    }

    private void AquaQuestTagUpdate(int index)
    {
        
        linesRight[index].SetActive(true);
    }
     private void PlantQuestTagUpdate(int index)
    {
        
        linesLeft[index].SetActive(true);
    }





   
}
