using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GroundEvent : MonoBehaviour
{
    [Tooltip("Name of the Ground e.g. Sand, Grass")]
    public string m_groundType;

    [Tooltip("Object Triggering, by default object named \"Player\"")]
    public GameObject m_triggerObject;
    [Tooltip("Central Event System, by default object named \"ABFEventSystem\"")]
    public ABFEvents eventSystem;
    private static readonly string DEFAULT_TRIGGER_NAME = "Player";
    
    private Collider pm_collider;
    

    void Start()
    {
        pm_collider = GetComponent<Collider>();
        pm_collider.isTrigger = true;
        if(eventSystem == null)
        {
            GameObject obj = GameObject.Find(ABFEvents.DEFAULT_EVENT_SYSTEM_NAME);
            if(obj != null)
            {
                var evts = obj.GetComponent<ABFEvents>();
                if(evts != null)
                {
                    this.eventSystem = evts;
                }
                else
                {
                    Debug.LogError($"{name} has no event system");
                }
            }
            else
            {
                Debug.LogError($"{name} has no event system");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(this.m_triggerObject != null && this.m_triggerObject == other.gameObject)
        {
            trigger();
        }
        else if(GroundEvent.DEFAULT_TRIGGER_NAME.Equals(other.gameObject.name))
        {
            trigger();
        }
    }

    private void trigger()
    {
        eventSystem.SetGround(this.m_groundType);
    }
}