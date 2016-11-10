using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    public Image image;
    public float timeWait = 2.0f;
    public bool waiting = false;

    private float time = 0;

    public void Play()
    {
        if (!waiting)
        {
            if (image != null)
                image.fillAmount = 1;
            time = 0;
            waiting = true;
        }
    }

    public void Stop()
    {
        if(image != null)
            image.fillAmount = 1;
        time = 0;
        waiting = false;
    }

    void Update()
    {

        if (waiting)
            time += Time.deltaTime;

        if (waiting && image.fillAmount != 0 && time > 0.5f)
        {
            image.fillAmount -= Time.deltaTime / timeWait;
        }

        if (image.fillAmount == 0 && waiting)
        {
            waiting = false;
            time = 0;
            GameManager.Instance.DateUnPaseo(this.transform.position);
        }
    }

}
