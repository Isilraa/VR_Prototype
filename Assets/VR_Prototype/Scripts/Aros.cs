using UnityEngine;

public class Aros : MonoBehaviour, IGvrGazeResponder
{
    private float timeInObject = 0f;
    private bool inObject = false;
    private Vector3 direction;

    public float timeToDrag = 1f;
    public float speed = 0.2f;
    private float offsetY = 0f;
    public float elevationSpeed = 0.2f;
    public Transform palo;

    private Renderer rend;

    void Start()
    {
        rend = GameManager.Instance.Reticle.GetComponent<Renderer>();
    }

    public void OnGazeEnter()
    {
        // El chivato ha sustituido a esta función
    }

    public void OnGazeExit()
    {
        // El chivato ha sustituido a esta función 
    }

    public void OnGazeTrigger()
    {
        Debug.Log("hago click en el aro");
    }

    void Update()
    {
        if (inObject)
        {
            timeInObject += Time.deltaTime;
            float colorValue = 1 - (timeInObject / (timeToDrag));
            if (colorValue > 0)
            {
                rend.material.color = new Color(colorValue, colorValue, 1);
            }
        }
        // Si tenemos el aro agarrado
        if (timeInObject > timeToDrag)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            offsetY = elevationSpeed * Time.deltaTime;
            if (offsetY > 4f)
                offsetY = 4f;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            transform.position += new Vector3(0, offsetY, 0);
        }
    }

    void OnChivatoEnter()
    {
        Debug.Log("entramos en el aro");
        direction = palo.transform.position - transform.position;
        inObject = true;

        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.useGravity = false;
        rBody.freezeRotation = true;
    }
    void OnChivatoExit()
    {
        Debug.Log("salimos de el aro");
        timeInObject = 0f;
        inObject = false;
        GetComponent<Rigidbody>().isKinematic = false;
        rend.material.color = new Color(1, 1, 1);
        offsetY = 0f;

        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.useGravity = true;
        rBody.freezeRotation = false;   
    }
}
