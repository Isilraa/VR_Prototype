using UnityEngine;
using System.Collections;
using System;

public class Aros : MonoBehaviour, IGvrGazeResponder
{
    public void OnGazeEnter()
    {
        Debug.Log("entramos en el aro");
    }

    public void OnGazeExit()
    {
        Debug.Log("salimos de el aro");
    }

    public void OnGazeTrigger()
    {
        Debug.Log("hago click en el aro");
    }
}
