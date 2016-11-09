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

    public void Awake()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
        if (particles == null)
            particles = GetComponentInChildren<ParticleSystem>();
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
            animator.SetBool("playing", !animator.GetBool("playing"));

            if (audio.isPlaying)
            {
                audio.Stop();
                if (particles != null)
                    particles.Stop();
            }
            else
            {
                audio.Play();
                if (particles != null)
                    particles.Play();
            }

            timeInObject = 0;
        }
    }
}
