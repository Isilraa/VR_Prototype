using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject Reticle;

    public static GameManager Instance { private set; get; }

    private Vector3 target;
    public Fades fades;
    public bool walking = false;
    public float speed = 5.0f;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void DateUnPaseo(Vector3 objetivo)
    {
        target = objetivo;
        walking = true;
        //StartCoroutine(APasear());
    }

    void Update()
    {
        if(walking)
        {
            Vector3 dir = target - Player.transform.position;

            if (dir.magnitude > 0.25f)
            {
                dir.Normalize();
                Player.transform.Translate(dir * speed * Time.deltaTime);
            }
            else
                walking = false;
        }

        if (fades.finished)
        {
            SceneManager.LoadSceneAsync("MainMenu");
            fades.finished = false;
        }
    }

    IEnumerator APasear()
    {
        while (walking)
        {
            Vector3 dir = target - Player.transform.position;

            if (dir.magnitude > 0.25f)
            {
                dir.Normalize();
                Player.transform.Translate(dir * speed * Time.deltaTime);
            }
            else
                walking = false;

            
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
