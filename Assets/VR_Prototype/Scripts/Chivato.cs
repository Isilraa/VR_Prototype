using UnityEngine;


public class Chivato : MonoBehaviour, IGvrGazeResponder
{
    public void OnGazeEnter()
    {
        SendMessageUpwards("OnChivatoEnter");
    }

    public void OnGazeExit()
    {
        SendMessageUpwards("OnChivatoExit");
    }

    public void OnGazeTrigger()
    {
    }
}
