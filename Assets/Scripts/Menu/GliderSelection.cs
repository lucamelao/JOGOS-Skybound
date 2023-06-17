using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GliderSelection : MonoBehaviour
{

    public Image shop;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _warrning;
    public AudioSource buySound;
    Treasury treasury;
    Glider glider;

    public GameObject[] gliders;
    public int selecetedGlider = 0;

    void Start(){
        treasury = Treasury.GetInstance();
        glider = Glider.GetInstance();

        for(int i = 0; i < gliders.Length; i++){
          if(glider.GliderUnlocked[i]) {
            gliders[i].GetComponent<GliderType>().Unlock();
          }
        }
    }

    public void NextGlider(){
        gliders[selecetedGlider].SetActive(false);
        selecetedGlider = (selecetedGlider + 1) % gliders.Length;
        gliders[selecetedGlider].SetActive(true);
    }

    public void PreviousGlider(){
        gliders[selecetedGlider].SetActive(false);
        selecetedGlider--;
        if(selecetedGlider < 0){
            selecetedGlider = gliders.Length - 1;
        }
        gliders[selecetedGlider].SetActive(true);
    }

    public void OpenShop(){
        shop.gameObject.SetActive(true);
        _price.text = gliders[selecetedGlider].GetComponent<GliderType>().price.ToString();
    }

    public void Buy(){
        if(treasury.Spend(gliders[selecetedGlider].GetComponent<GliderType>().price)){
            glider.GliderUnlocked[selecetedGlider] = true;
            gliders[selecetedGlider].GetComponent<GliderType>().Unlock();
            glider.Save();
            buySound.Play(0);
            shop.gameObject.SetActive(false);
        }
        else{
            _warrning.gameObject.SetActive(true);
            StartCoroutine(FadeTextToZeroAlpha(1f, _warrning));
        }
    }


    public void StartGame(){
        if(glider.GliderUnlocked[selecetedGlider]){
            PlayerPrefs.SetInt("selectedGlider", selecetedGlider);
            SceneManager.LoadScene("Main");
        }
        else{
            OpenShop();
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, TMP_Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, TMP_Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
