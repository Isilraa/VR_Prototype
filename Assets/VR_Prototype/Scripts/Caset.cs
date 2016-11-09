using UnityEngine;
using System.Collections;
using System;

public class Caset : MonoBehaviour, IGvrGazeResponder
{
    public void OnGazeEnter()
    {
        Debug.Log("entramos en el caset");
    }

    public void OnGazeExit()
    {
        Debug.Log("salimos de el caset");
    }

    public void OnGazeTrigger()
    {
        Debug.Log("hago click en el caset");
    }
}
