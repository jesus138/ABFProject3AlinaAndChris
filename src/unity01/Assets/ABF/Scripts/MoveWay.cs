using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// please see Unity Manual page for Vector3.Lerp for understanding
// the linear interpolation between two points based on a given speed
public class MoveWay : MonoBehaviour
{
    /**
      * v in u/s (speed)
      * t in s (delta time)
      * v*t -> w in u (way in units)
      * vector3 d (direction)
      * magnitude m (length of d)
      * m(d) shall be w
      * factor x = abs(w/m)
      */
    [Tooltip("Speed in units per second")]
    public float Speed = 3.0F;
    [Tooltip("Way Markers")]
    public Transform[] Markers;

    private int Index;
    private bool forward;
    private Vector3 direction;
    private float fullway;
    private float walked;

    // Start is called before the first frame update
    void Start()
    {
        forward = true;

        // 1. Get nearest point
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
                this.Index = i;
            }
        }
        NextPointInit();
    }

    // Update is called once per frame
    void Update()
    {
        if(walked < fullway)
        {
            float way = Speed * Time.deltaTime;
            float scale = Mathf.Abs(way/direction.magnitude);
            Vector3 move = direction*scale;
            transform.position += move;
            walked += move.magnitude;
        }
        else
        {
            if(forward)
            {
                if(Index+1<Markers.Length)
                {
                    Index++;
                }
                else
                {
                    forward = false;
                    Index--;
                }
            }
            else
            {
                if(Index-1>=0)
                {
                    Index--;
                }
                else
                {
                    forward = true;
                    Index++;
                }
            }
            NextPointInit();
        }
    }

    void NextPointInit()
    {
        Vector3 from = transform.position;
        Vector3 to = Markers[Index].position;
        direction = to-from;
        fullway = direction.magnitude;
        walked = 0;
    }
}
