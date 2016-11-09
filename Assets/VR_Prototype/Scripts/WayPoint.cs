using UnityEngine;
using System.Collections;
using System;

public class WayPoint : MonoBehaviour, IGvrGazeResponder
{
    public void OnGazeEnter()
    {
        Debug.Log("entramos en la caja");
    }

    public void OnGazeExit()
    {
        Debug.Log("salimos de la caja");
    }

    public void OnGazeTrigger()
    {
        Debug.Log("hago click en la caja");
    }
}
