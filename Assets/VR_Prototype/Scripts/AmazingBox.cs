using UnityEngine;
using System.Collections;
using System;

public class AmazingBox : MonoBehaviour, IGvrGazeResponder
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
        Destroy(gameObject);
    }
}
