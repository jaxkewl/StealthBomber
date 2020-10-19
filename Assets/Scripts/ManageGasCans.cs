using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGasCans : MonoBehaviour
{
    List<GameObject> cans = new List<GameObject>();
    public int canCount;
    public GameObject canPreFab;
    
    public int fuelAmount;
    // Start is called before the first frame update
    void Start()
    {
        //randomize a list of gas cans and their positions
        

        System.Random rnd = new System.Random();

        for (int i = 0; i < canCount; ++i)
        {
            int x = rnd.Next(1, 10000);
            int y = rnd.Next(1, 2000);
            int z = rnd.Next(1, 10000);
            GameObject gasBottle = GameObject.Instantiate(canPreFab);
            gasBottle.transform.position= new Vector3(x, y, z);
            cans.Add(gasBottle);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject go in cans)
        {
            go.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * 2);
        }
        
    }
}
