using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour, IGvrGazeResponder
{
    private float timeInObject = 0f;
    private bool inObject = false;

    public GameObject lights;
    public float timeToPlay = 1f;

    private GvrAudioSource audio;
    private Animator animator;

    public void Awake()
    {
        audio = GetComponent<GvrAudioSource>();
        animator = GetComponent<Animator>();
    }

    public void OnGazeEnter()
    {
        inObject = true;
    }

    public void OnGazeExit()
    {
        inObject = false;
        timeInObject = 0f;
    }

    public void OnGazeTrigger()
    {
    }

    void Update()
    {
        if (inObject)
            timeInObject += Time.deltaTime;

        if (timeInObject > timeToPlay)
        {
            lights.SetActive(!lights.activeSelf);

            timeInObject = 0;
        }
    }
}