using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settings : MonoBehaviour{

    public AudioMixer audioMixer;
    Resolution[] resolutions;

    void Start() {
        
    }

    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }
}
