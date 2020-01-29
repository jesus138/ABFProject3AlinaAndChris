using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ABFEvents : MonoBehaviour
{
    [Tooltip("Initial Ground Type")]
    public string m_initialGround;
    public delegate void GroundChange(string type);
    public event GroundChange GroundEvent;
    private string currentGround;
    public static readonly string DEFAULT_EVENT_SYSTEM_NAME = "ABFEventSystem";

    void Start()
    {
        if(m_initialGround != null)
        {
            this.currentGround = m_initialGround;
        }
    }

    public void SetGround(string type)
    {
        this.currentGround = type;
        if(this.GroundEvent != null)
        {
            this.GroundEvent(type);
        }
    }

    public string GetGround()
    {
        return this.currentGround;
    }
}