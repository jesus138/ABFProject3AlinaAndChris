using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CityMix : MonoBehaviour
{
    [Tooltip("Audio Mixer with CityVolume")]
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
            Debug.LogWarning("In the City");
            audioMixer.SetFloat("CityVolume", 0);
            audioMixer.SetFloat("NatureVolume", -40);
            audioMixer.SetFloat("WaterVolume", -80);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name.Equals("Player"))
        {
            Debug.LogWarning("Out of City");
            audioMixer.SetFloat("CityVolume", -40);
            audioMixer.SetFloat("NatureVolume", 0);
            audioMixer.SetFloat("WaterVolume", -20);
        }
    }
}
