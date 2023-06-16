using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdButton : MonoBehaviour
{
    public RewardedAds rewardedAds; 
    public Button myButton;
    public AdsBar adsBar;
    private int _time = 5;

    void Start()
    {
        adsBar.Init(_time);
        if(myButton)
        {
            StartCoroutine(DisableButtonAfterSeconds(_time));
        }
    }

    public void OnButtonClick()
    {
        rewardedAds.LoadAndShowAd();
    }

    IEnumerator DisableButtonAfterSeconds(int seconds)
    {
        for (int i = 0; i < seconds * 100; i++)
        {
            adsBar.UpdateBar(i / 100f);
            yield return new WaitForSeconds(0.01f);
        }
        myButton.gameObject.SetActive(false);
        adsBar.gameObject.SetActive(false);
    }
}