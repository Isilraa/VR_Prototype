using UnityEngine;
using System.Collections;
using System;

public class Lampara : MonoBehaviour, IGvrGazeResponder
{
    public void OnGazeEnter()
    {
        Debug.Log("entramos en la lampàra");
    }

    public void OnGazeExit()
    {
        Debug.Log("salimos de la lampàra");
    }

    public void OnGazeTrigger()
    {
        Debug.Log("hago click en la lampàra");
    }
}
