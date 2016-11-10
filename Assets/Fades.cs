using UnityEngine;
using System.Collections;
using System;

public class Fades : MonoBehaviour {
    [Range(0.01f, 0.1f)]
    public float fadeInVelocity;
    [Range(0.01f, 0.1f)]
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
        StartCoroutine(FadeOut());
    }

    public void StartFadeIn()
    {
        finished = false;
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        while (meshPlane.material.color.a < 1f)
        {
            Color colorPlane = meshPlane.material.color;
            meshPlane.material.color = new Color(colorPlane.r, colorPlane.g, colorPlane.b, colorPlane.a + fadeOutVelocity);
            yield return null;
        }
        if (meshPlane.material.color.a >= 1f)
        {
            finished = true;
        }
    }
    private IEnumerator FadeIn()
    {
        while (meshPlane.material.color.a > 0.05f)
        {
            Color colorPlane = meshPlane.material.color;
            meshPlane.material.color = new Color(colorPlane.r, colorPlane.g, colorPlane.b, colorPlane.a - fadeInVelocity);
            yield return null;
        }
    }
}
