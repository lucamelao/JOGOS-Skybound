using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum AdState
{
  None,
  Watching,
  Skipped,
  Completed
}
public class AdButton : MonoBehaviour
{
    public RewardedAds rewardedAds; 
    public Button myButton;
    public AdsBar adsBar;
    public int time = 5;
    public bool hasWatchedAd = false;

    public AdState adState;

    void Start()
    {
        if(myButton)
        {
            myButton.gameObject.SetActive(false);
        }
    }

    public void Init()
    {
        adState = AdState.None;
        if (myButton && adsBar)
        {
            myButton.gameObject.SetActive(true);
            adsBar.gameObject.SetActive(true);
            adsBar.Init(time);
            StartCoroutine(DisableButtonAfterSeconds(time));
        }
    }

    public void OnButtonClick()
    {
        Debug.Log("OnButtonClick SHOW AD");
        adState = AdState.Watching;
        rewardedAds.LoadAndShowAd();
    }

    IEnumerator DisableButtonAfterSeconds(int seconds)
    {
        for (int i = 0; i < seconds * 100; i++)
        {
            if(adState != AdState.None) break;
            adsBar.UpdateBar(i / 100f);
            yield return new WaitForSeconds(0.01f);
        }
        if(adState == AdState.None)
        {
            adState = AdState.Skipped;
        }
        myButton.gameObject.SetActive(false);
        adsBar.gameObject.SetActive(false);
    }
}
