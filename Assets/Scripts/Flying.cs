using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Flying : MonoBehaviour
{
    public float power;
    public GameObject plane;
    private Rigidbody rb;

    public float pitchGain;
    public float rollGain;
    public float yawGain;
    public TextMeshProUGUI score;
    public int collectedCanCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        collectedCanCount = 0;
        score.text = "Score: 0";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isSpace = Input.GetKey(KeyCode.Space);
        bool isShift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isRight = Input.GetKey(KeyCode.RightArrow);
        bool isLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isPitchUp = Input.GetKey(KeyCode.UpArrow);
        bool isPitchDown = Input.GetKey(KeyCode.DownArrow);
        bool isA = Input.GetKey(KeyCode.A);
        bool isD = Input.GetKey(KeyCode.D);

        Vector3 rotZ = new Vector3(0.0f, 0.0f, -0.1f * rollGain);
        Vector3 rotY = new Vector3(0.0f, 0.1f * yawGain, 0.0f);
        Vector3 rotX = new Vector3(0.1f * pitchGain, 0.0f, 0.0f);

        if (isSpace) plane.transform.Rotate(rotZ);
        else if (isShift) plane.transform.Rotate(-rotZ);

        if (isRight && plane.transform.rotation.x <= 90)
        {
            //plane.transform.Rotate(rotX);
            plane.transform.Rotate(rotY);
        }
        else if (isLeft && plane.transform.rotation.x >= -90)
        {
            //plane.transform.Rotate(-rotX);
            plane.transform.Rotate(-rotY);
        }

        if (isPitchUp)
        {
            plane.transform.Rotate(Input.GetAxis("Vertical"), 0f, 0f);
        }
        else if (isPitchDown)
        {
            plane.transform.Rotate(-rotX);
        }

        if (isA)
        {
            rb.AddRelativeForce(Vector3.forward * power * 100);
            //plane.transform.Rotate(-rotX);
        }
        else if (isD)
        {
            rb.AddRelativeForce(Vector3.forward * power * -100);
            //plane.transform.Rotate(rotX);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!");
        if (other.gameObject.CompareTag("Gas"))
        {
            other.gameObject.SetActive(false);
            ++collectedCanCount;
            Debug.Log($"total collected cans {collectedCanCount}");
            score.text = "Score: " + collectedCanCount.ToString();
        }
    }
}
