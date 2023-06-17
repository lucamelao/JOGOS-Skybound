using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _hs;
    Score score;

    void Start(){
        score = Score.GetInstance();
        _hs.text = score._highScore.ToString();
    }
}
