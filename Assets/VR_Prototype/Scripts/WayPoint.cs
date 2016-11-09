using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour, IGvrGazeResponder
{
    public Image image;
    public float timeWait = 2.0f;
    bool waiting = false;

    public void OnGazeEnter()
    {
        Debug.Log("entramos en la caja");
        waiting = true;
        StartCoroutine(FillingWhileWait());
    }

    public void OnGazeExit()
    {
        if(image != null)
            image.fillAmount = 1;
        waiting = false;
    }

    public void OnGazeTrigger()
    {
        Debug.Log(gameObject.name + ": nada");
    }

    IEnumerator FillingWhileWait()
    {
        while(waiting && image.fillAmount != 0)
        {
            image.fillAmount -= Time.deltaTime / timeWait;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        if (image.fillAmount == 0)
        {
            GameManager.Instance.DateUnPaseo(this.transform.position);
            WaypointsController.Instance.DeactivateWaypoint(gameObject);
        }

        waiting = false;
        image.fillAmount = 1;
    }


}
