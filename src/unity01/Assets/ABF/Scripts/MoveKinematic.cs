using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// please see Unity Manual page for Vector3.Lerp for understanding
// the linear interpolation between two points based on a given speed
public class MoveKinematic : MonoBehaviour
{
    [Tooltip("Speed in units per second")]
    public float Speed = 3.0F;
    [Tooltip("Way Markers")]
    public Transform[] Markers;

    // current index in Markers that is goal
    private int I;
    private bool back;
    // starting position
    private Transform start;
    private float startTime;
    private float way;

    // Start is called before the first frame update
    void Start()
    {
        back = false;
        start = transform;  // start with the object's position
        startTime = Time.time;

        // 1. determine the nearest point in Markers
        // and set it as goal
        float dist = Mathf.Infinity;
        for(int i = 0; i < Markers.Length; i++)
        {
            Vector3 point = Markers[i].position;
            float px = point.x;
            float pz = point.z;
            float d = Vector3.Distance(transform.position, point);
            if(d < dist)
            {
                dist = d;
                this.I = i;
            }
        }
        way = dist;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 goal = Markers[I].position;
        float distCovered = (Time.time - startTime) * Speed;
        float fraction = distCovered / way;
        transform.position = Vector3.Lerp(start.position, goal, fraction);

        bool change = false;
        if(fraction >= 1.0F)
        {
            change = true;
            if(!back)
            {
                if(I<Markers.Length+1)
                {
                    I++;
                }
                else
                {
                    back = true;
                    I--;
                }
            }
            else
            {
                if(I>0)
                {
                    I--;
                }
                else
                {
                    back = false;
                    I++;
                }
            }
        }

        if(change)
        {
            goal = Markers[I].position;
            startTime = Time.time;
            start = transform;
            way = Vector3.Distance(start.position, goal);
        }
    }
}
