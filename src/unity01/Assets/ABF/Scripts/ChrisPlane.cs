using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        Vector3 pos = collision.transform.position;
        Vector3 posl = collision.transform.localPosition;
        Debug.Log($"collided with {name} at {pos} (local: {posl})");
    }
}
