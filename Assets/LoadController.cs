﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LoadController : MonoBehaviour, IGvrGazeResponder {

    private Animator animator;
    public bool load;
    public Fades fades;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnGazeEnter()
    {
        animator.SetBool("loading", true);
    }

    public void OnGazeExit()
    {
        if (animator != null)
            animator.SetBool("loading", false);
    }

    public void OnGazeTrigger()
    {
        
    }

    void Update()
    {
        if (load)
        {
            load = false;
            fades.StartFadeOut();
        }
        if (fades.finished)
        {
            SceneManager.LoadScene("mainScene");
        }
    }
}
