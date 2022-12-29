using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public static int count = 0;
    Vector3 endPosition;
    Vector3 pathBlockInitPos;
    public GameObject pathBlock;
    public GameObject cube;
    public Material mat;
    bool isRotation = true;

    public static event Action<int> frostStonee;

    private void Update()
    {
        if (isRotation)
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    private void Awake()
    {
        pathBlockInitPos = pathBlock.transform.localPosition;
        endPosition = new Vector3(pathBlockInitPos.x, 25, pathBlockInitPos.z);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            isRotation = false;
            Destroy();

        }
    }
    void Destroy()
    {
       
        cube.GetComponent<MeshRenderer>().material = mat;
        count++;
        if (count == 3)
        {
            StartCoroutine(PositionLerp(pathBlock.transform.localPosition, endPosition, 2f));
            frostStonee?.Invoke(1);
            
        }
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

    }


    IEnumerator PositionLerp(Vector3 startPosition, Vector3 endPosition, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            pathBlock.transform.localPosition = Vector3.Lerp(startPosition, endPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        pathBlock.transform.localPosition = endPosition;

    }
   
}
