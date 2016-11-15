using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour, IGvrGazeResponder
{
    private float timeInObject = 0f;
    public float timeToLoad = 3.0f;
    private bool loaded = false;
    private Renderer rend;
    private bool inObject = false;
    private AudioSource audio;

    void Start()
    {
        rend = GameManager.Instance.Reticle.GetComponent<Renderer>();
        audio = GetComponent<AudioSource>();
    }

    public void OnGazeEnter()
    {
        inObject = true;
    }

    public void OnGazeExit()
    {
        inObject = false;
        timeInObject = 0f;
        rend.material.color = new Color(1, 1, 1);
    }

    public void OnGazeTrigger()
    {

    }

    void Update()
    {
        if (inObject)
        {
            timeInObject += Time.deltaTime;
            float colorValue = 1 - (timeInObject / (timeToLoad));
            if (colorValue > 0)
            {
                rend.material.color = new Color(colorValue, colorValue, colorValue);
            }

            if (!loaded && timeInObject > timeToLoad)
            {
                GameManager.Instance.fades.StartFadeOut();
                audio.Play();
                loaded = true;
            }
        }
    }
}
