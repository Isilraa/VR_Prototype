using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour, IGvrGazeResponder
{
    private float timeInObject = 0f;
    private bool inObject = false;

    public GameObject lights;
    public float timeToPlay = 1f;
    public AudioClip lightOn;
    public AudioClip lightOff;

    private AudioSource audio;
    private Animator animator;

    private Renderer rend;


    public void Awake()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rend = GameManager.Instance.Reticle.GetComponent<Renderer>();

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
            float colorValue = 1 - (timeInObject / (timeToPlay));
            if (colorValue > 0)
            {
                rend.material.color = new Color(colorValue, colorValue, colorValue);
            }
        }

        if (timeInObject > timeToPlay)
        {
            if (lights.activeSelf)
                audio.clip = lightOn;
            else
                audio.clip = lightOff;

            lights.SetActive(!lights.activeSelf);
            audio.Play();
            timeInObject = 0;
        }
    }
}