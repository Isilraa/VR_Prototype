using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class MusicController : MonoBehaviour, IGvrGazeResponder
{
    private float timeInObject = 0f;
    private bool inObject = false;

    public float timeToPlay = 1f;

    private AudioSource audio;
    private Animator animator;
    private ParticleSystem particles;


    public AudioClip turnedOn;
    public AudioClip turnedOff;
    public AudioClip music;

    private Renderer rend;

    private bool on = false;

    public void Awake()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
        if (particles == null)
            particles = GetComponentInChildren<ParticleSystem>();
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
            animator.SetBool("playing", !animator.GetBool("playing"));

            if (!on)
                StartCoroutine(TurnOn());
            else
            {
                audio.clip = turnedOff;
                audio.Play();
                particles.Stop();
            }

            on = !on;
            timeInObject = 0;
        }
    }

    IEnumerator TurnOn()
    {
        audio.clip = turnedOn;
        audio.Play();
        yield return new WaitForSeconds(0.1f);

        while(audio.isPlaying)
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }

        particles.Play();
        audio.clip = music;
        audio.Play();
    }

}
