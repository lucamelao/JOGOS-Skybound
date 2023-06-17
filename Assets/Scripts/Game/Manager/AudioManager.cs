using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource1; 
    public AudioSource audioSource2; 
    public AudioSource audioSource3; 
    public AudioSource audioSource4; 
    public AudioSource audioSource5; 
    public AudioSource audioSource6; 

    public void PlaySound(int soundNumber)
    {
        switch (soundNumber)
        {
            case 1:
                if (audioSource1 != null && audioSource1.enabled)
                {
                    audioSource1.Play();
                }
                break;
            case 2:
                if (audioSource2 != null && audioSource2.enabled)
                {
                    audioSource2.Play();
                }
                break;
            case 3:
                if (audioSource3 != null && audioSource3.enabled)
                {
                    audioSource3.Play();
                }
                break;
            case 4:
                if (audioSource4 != null && audioSource4.enabled)
                {
                    audioSource4.Play();
                }
                break;
            case 5:
                if (audioSource5 != null && audioSource5.enabled)
                {
                    audioSource5.Play();
                }
                break;
            case 6:
                if (audioSource6 != null && audioSource6.enabled)
                {
                    audioSource6.Play();
                }
                break;
            case 7:
                if (audioSource6 != null && audioSource1.enabled)
                {
                    audioSource6.Stop();
                }
                break;
            default:
                Debug.LogError("Invalid sound number");
                break;
        }
    }
}