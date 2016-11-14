using UnityEngine;
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
        if (animator != null && !load)
            animator.SetBool("loading", true);
    }

    public void OnGazeExit()
    {
        if (animator != null && !load)
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
            animator.enabled = false;
            fades.StartFadeOut();
        }
        if (fades.finished)
        {
            fades.finished = false;
            //SceneManager.LoadScene("mainScene");
            StartCoroutine(Load());
        }
    }

    IEnumerator Load()
    {
        AsyncOperation a = SceneManager.LoadSceneAsync("mainScene");
        a.allowSceneActivation = true;
        while (!a.isDone)
        {
            yield return null;
        }
    }
}
