using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WaterMix : MonoBehaviour
{
    [Tooltip("Audio Mixer with WaterVolume")]
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals("Player"))
        {
            Debug.LogWarning("At the Water");
            audioMixer.SetFloat("CityVolume", -80);
            audioMixer.SetFloat("NatureVolume", -10);
            audioMixer.SetFloat("WaterVolume", 20);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name.Equals("Player"))
        {
            Debug.LogWarning("Away from Water");
            audioMixer.SetFloat("CityVolume", -60);
            audioMixer.SetFloat("NatureVolume", 0);
            audioMixer.SetFloat("WaterVolume", -20);
        }
    }
}
