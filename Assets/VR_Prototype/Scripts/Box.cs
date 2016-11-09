using UnityEngine;
using System.Collections;
using System;

public class Box : MonoBehaviour, IGvrGazeResponder
{
    private float timeInObject = 0f;
    private bool inObject = false;
    private Vector3 distance;

    public float timeToDrag = 1f;
    public float smooth = 1f;

    private GameObject cam;

    public void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void OnGazeEnter()
    {
        Debug.Log("entramos en la caja");
        inObject = true;
        distance = transform.position - cam.transform.position;
        GetComponent<Rigidbody>().useGravity = false;
    }

    public void OnGazeExit()
    {
        Debug.Log("salimos de la caja");
        inObject = false;
        timeInObject = 0f;
        GetComponent<Rigidbody>().useGravity = true;
    }

    public void OnGazeTrigger()
    {
        Debug.Log("hago click en la caja");
    }

    void Update()
    {
        if (inObject)
            timeInObject += Time.deltaTime;

        if (timeInObject > timeToDrag)
        {
            transform.position = Vector3.Lerp(transform.position, cam.transform.position + cam.transform.forward * distance.magnitude, Time.deltaTime * smooth);
        }
    }
}
