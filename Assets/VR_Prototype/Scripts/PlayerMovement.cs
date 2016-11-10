using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public GameObject waypoint;
    public float distance = 1.0f;

    private GvrGaze gaze;
    private Renderer reticleRender;
    private WayPoint waypointController;
    private Vector3 lastPos;
    

    private bool gazing = false;

    void Start()
    {
        gaze = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GvrGaze>();
        reticleRender = GameManager.Instance.Reticle.GetComponent<Renderer>();
        waypointController = waypoint.GetComponent<WayPoint>();

        waypoint.SetActive(gazing);
    }

    void Update()
    {
        if (gaze.currentGazeObject != null)
            gazing = gaze.currentGazeObject.tag == "Floor";

        if (gazing && !GameManager.Instance.walking)
        {
            if (!waypoint.activeSelf)
                waypoint.SetActive(true);
            waypoint.transform.position = new Vector3(gaze.lastIntersectPosition.x, waypoint.transform.position.y, gaze.lastIntersectPosition.z);

            float currDis = (gaze.lastIntersectPosition - lastPos).magnitude;
            lastPos = gaze.lastIntersectPosition;

            if (currDis <= distance && !waypointController.waiting)
                waypointController.Play();

            else if (currDis > distance && waypointController.waiting)
                waypointController.Stop();
        }
        else
        {
            if (waypoint.activeSelf)
                waypoint.SetActive(false);

            if (waypointController.waiting)
                waypointController.Stop();
        }

        
            
    }
}
