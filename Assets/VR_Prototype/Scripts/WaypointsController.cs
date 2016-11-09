using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointsController : MonoBehaviour {

    public List<GameObject> waypoints;

    public static WaypointsController Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

	public void DeactivateWaypoint(GameObject punto)
    {
        foreach(GameObject waypoint in waypoints)
        {
            waypoint.SetActive(waypoint.name != punto.name);
        }
    }
}
