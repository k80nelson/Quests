using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

    // Use this for initialization
    public Slider volumeSlider;
    public AudioSource volumeAudio;

    // Update is called once per frame
    void Update()
    {
        volumeAudio.volume = volumeSlider.value;
    }
    
}
