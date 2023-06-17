using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selector : MonoBehaviour
{
    [SerializeField] public bool unlocked = false;

    public Image unlockImage;

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

    public void PressSelection(string _LevelName){
        if(unlocked){
            SceneManager.LoadScene(_LevelName);
        }
    }

}