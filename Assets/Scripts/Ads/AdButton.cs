using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdButton : MonoBehaviour
{
    public RewardedAds rewardedAds; 
    public Button myButton;
    public AdsBar adsBar;
    private int _time = 10;

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
        for (int i = 0; i < seconds; i++)
        {
            adsBar.UpdateBar(i);
            yield return new WaitForSeconds(1);
        }
        myButton.gameObject.SetActive(false);
    }
}