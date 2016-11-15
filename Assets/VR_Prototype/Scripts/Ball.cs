using UnityEngine;

public class Ball : MonoBehaviour, IGvrGazeResponder
{
    private float timeInObject = 0f;
    private bool inObject = false;
    private Vector3 distance;

    public float timeToDrag = 1f;
    public float smooth = 14f;

    private GameObject cam;
    private Renderer rend;
    private Transform alfombraTransform;
    private AudioSource source;
    private SphereCollider col;


    void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
        rend = GameManager.Instance.Reticle.GetComponent<Renderer>();

        source = GetComponent<AudioSource>();

        alfombraTransform = GameObject.FindGameObjectWithTag("Alfombra").transform;

        col = GetComponentInChildren<SphereCollider>();



    }

    public void OnGazeEnter()
    {

    }

    public void OnGazeExit()
    {

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
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = Vector3.Lerp(transform.position, cam.transform.position + cam.transform.forward * distance.magnitude, Time.deltaTime * smooth);

            if (transform.position.y < alfombraTransform.position.y + col.radius)
            {
                transform.position = new Vector3(transform.position.x, alfombraTransform.position.y + col.radius, transform.position.z);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (source != null)
            source.Play();
    }

    void OnChivatoEnter()
    {
        Debug.Log("entramos en la caja");
        inObject = true;
        distance = transform.position - cam.transform.position;
        GetComponent<Rigidbody>().useGravity = false;
    }
    void OnChivatoExit()
    {
        Debug.Log("salimos de la caja");
        inObject = false;
        timeInObject = 0f;
        GetComponent<Rigidbody>().isKinematic = false;
        rend.material.color = new Color(1, 1, 1);

        GetComponent<Rigidbody>().useGravity = true;
    }
}
