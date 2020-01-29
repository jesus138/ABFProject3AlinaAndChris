using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABFUI : MonoBehaviour
{
    [Tooltip("Central Event System, by default object named \"ABFEventSystem\"")]
    public ABFEvents eventSystem;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();

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

        eventSystem.GroundEvent += OnGroundChange;
    }

    void Update()
    {
        
    }

    void OnGroundChange(string type)
    {
        text.text = type;
    }
}
