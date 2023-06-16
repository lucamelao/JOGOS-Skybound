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
        if(myButton)
        {
            myButton.gameObject.SetActive(false);
        }
    }

    public void Init()
    {
        if (myButton && adsBar)
        {
            myButton.gameObject.SetActive(true);
            adsBar.gameObject.SetActive(true);
            adsBar.Init(_time);
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
