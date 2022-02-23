using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{

    readonly float G = 1f;
    GameObject[] celestials;

    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestials");
    }

  
   

    private void Update()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestials");
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    void Gravity()
    {
        foreach (GameObject x in celestials)
        {
            foreach (GameObject y in celestials)
            {
                if (!x.Equals(y))
                {
                    float m1 = x.GetComponent<Rigidbody>().mass;
                    float m2 = y.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(x.transform.position, y.transform.position);

                    x.GetComponent<Rigidbody>().AddForce((y.transform.position - x.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }

  
}
