using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GliderType : MonoBehaviour
{
    [SerializeField] public int price = 0;
    [SerializeField] public bool unlocked = false;
    [SerializeField] public float glideTime = 0.0f;
    public Slider slider;

    public Image unlockImage;

    public void Unlock()
    {
        unlocked = true;
        UpdateLevelImage();
    }

    private void Start() {
        slider.value = glideTime;
    }

    private void Update() {
        UpdateLevelImage();
    }

    private void UpdateLevelImage(){
        if(!unlocked){
            unlockImage.gameObject.SetActive(true);
        }
        else{
            unlockImage.gameObject.SetActive(false);
        }
    }
}
