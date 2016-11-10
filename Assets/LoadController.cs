using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LoadController : MonoBehaviour, IGvrGazeResponder {

    private Animator animator;
    public bool load;

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
        animator.SetBool("loading", false);
    }

    public void OnGazeTrigger()
    {
        
    }

    void Update()
    {
        if (load)
            SceneManager.LoadScene("mainScene");
    }
}
