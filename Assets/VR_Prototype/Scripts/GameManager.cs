﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject Player;

    public static GameManager Instance { private set; get; }

    private Vector3 target;
    private bool walking = false;
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
        StartCoroutine(APasear());
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