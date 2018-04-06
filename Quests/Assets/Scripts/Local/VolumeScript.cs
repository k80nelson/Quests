using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour
{

    // Use this for initialization
    public UnityEngine.UI.Slider volumeSlider;
    public AudioSource volumeAudio;

    // Update is called once per frame
    void Update()
    {
        volumeAudio.volume = volumeSlider.value;

    }
        

}
