using UnityEngine;
using System.Collections;
using System;

public class Fades : MonoBehaviour {
    [Range(0.1f, 0.5f)]
    public float fadeInVelocity;
    [Range(0.1f, 0.5f)]
    public float fadeOutVelocity;
    private MeshRenderer meshPlane;

    public bool finished = false;

	// Use this for initialization
	void Start () {
        meshPlane = GetComponent<MeshRenderer>();
        StartFadeIn();
	}

    public void StartFadeOut()
    {
        finished = false;
        //gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    public void StartFadeIn()
    {
        finished = false;
        //gameObject.SetActive(true);
        StartCoroutine(FadeIn(gameObject));
    }

    private IEnumerator FadeOut()
    {
        while (meshPlane.material.color.a < 1f)
        {
            Color colorPlane = meshPlane.material.color;
            meshPlane.material.color = new Color(colorPlane.r, colorPlane.g, colorPlane.b, colorPlane.a + fadeOutVelocity * Time.deltaTime);
            yield return null;
        }
        if (meshPlane.material.color.a >= 1f)
        {
            finished = true;
        }
    }
    private IEnumerator FadeIn(GameObject go)
    {
        while (meshPlane.material.color.a > 0.05f)
        {
            Color colorPlane = meshPlane.material.color;
            meshPlane.material.color = new Color(colorPlane.r, colorPlane.g, colorPlane.b, colorPlane.a - fadeInVelocity * Time.deltaTime);
            yield return null;
        }
    }
}
