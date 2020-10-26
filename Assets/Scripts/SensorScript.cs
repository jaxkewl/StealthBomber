using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    public Material detected;
    public Material undetected;
    public int sensedCounter = 0;
    private GameObject parent;

    public Material illumMaterial;
    public Material normalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.parent.gameObject.transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Gas"))
        {
            sensedCounter++;
            Debug.Log($"Sensing a gas botle {sensedCounter}");

            Debug.Log($"parent name: {parent.name}");
            parent.GetComponent<Flying>().sensed.text = "Sensed: " + sensedCounter;
            Debug.Log($"clipped gascan: {other.gameObject.name}");
            //other.gameObject.GetComponent<Renderer>().material.color = Color.green;



            Material[] intMaterials = new Material[other.gameObject.GetComponent<MeshRenderer>().materials.Length];
            for (int i = 0; i < intMaterials.Length; i++)
            {
                intMaterials[i] = illumMaterial;
            }
            other.gameObject.GetComponent<MeshRenderer>().materials = intMaterials;

            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Gas"))
        {
            sensedCounter--;
            Debug.Log($"Leaving a sensed gas botle {sensedCounter}");
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
            
            Debug.Log($"parent name: {parent.name}");

           parent.GetComponent<Flying>().sensed.text = "Sensed: " + sensedCounter;
            Debug.Log($"L clipped gascan: {other.gameObject.name}");


            Material[] intMaterials = new Material[other.gameObject.GetComponent<MeshRenderer>().materials.Length];
            for (int i = 0; i < intMaterials.Length; i++)
            {
                intMaterials[i] = normalMaterial;
            }
            other.gameObject.GetComponent<MeshRenderer>().materials = intMaterials;
        }
    }
}
