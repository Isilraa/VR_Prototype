using UnityEngine;

public class Box : MonoBehaviour, IGvrGazeResponder
{
    private float timeInObject = 0f;
    private bool inObject = false;
    private Vector3 distance;

    public float timeToDrag = 1f;
    public float smooth = 14f;

    private GameObject cam;
    private Renderer rend;

    void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
        rend = GameManager.Instance.Reticle.GetComponent<Renderer>();
    }

    public void OnGazeEnter()
    {
        Debug.Log("entramos en la caja");
        inObject = true;
        distance = transform.position - cam.transform.position;
        GetComponent<Rigidbody>().useGravity = false;
    }

    public void OnGazeExit()
    {
        Debug.Log("salimos de la caja");
        inObject = false;
        timeInObject = 0f;
        rend.material.color = new Color(1, 1, 1);

        GetComponent<Rigidbody>().useGravity = true;
    }

    public void OnGazeTrigger()
    {
        Debug.Log("hago click en la caja");
    }

    void Update()
    {
        if (inObject)
        {
            timeInObject += Time.deltaTime;
            float colorValue = 1 - (timeInObject / (timeToDrag));
            if (colorValue > 0)
            {
                rend.material.color = new Color(colorValue, 1, colorValue);
            }
        }

        if (timeInObject > timeToDrag)
        {
            transform.position = Vector3.Lerp(transform.position, cam.transform.position + cam.transform.forward * distance.magnitude, Time.deltaTime * smooth);
        }
    }
}
