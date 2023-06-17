using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private string _androidAdUnitRewardedId = "Rewarded_Android";
    private string _adUnitId = null;
    public AdButton adButton;

    public AdDisplay adDisplay;

    void Start()
    {
      _adUnitId = _androidAdUnitRewardedId;
    }

    public void LoadAndShowAd()
    {
        Debug.Log("LoadAndShowAd first");
        if(adDisplay.initError) 
        {
            adButton.adState = AdState.Skipped;
            return;
        }
        if(adButton.adState != AdState.Watching) return;
        LoadAd();
        Debug.Log("LoadAndShowAd second");
    }


    void LoadAd()
    {
        Advertisement.Load(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        ShowAd();
    }

    void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }

public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
{
    if (adUnitId.Equals(_adUnitId) && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
    {
        Debug.Log("Unity Ads Rewarded Ad Completed");
        adButton.adState = AdState.Completed;
        //LoadAd(); // If you want to reload the ad after showing
    }
    else if (adUnitId.Equals(_adUnitId) && showCompletionState == UnityAdsShowCompletionState.SKIPPED)
    {
        Debug.Log("Unity Ads Rewarded Ad Skipped");
        adButton.adState = AdState.Skipped;
        // handle logic for skipped ad here if needed
    }
}



    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        adButton.adState = AdState.Skipped;
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        adButton.adState = AdState.Skipped;
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
    }
}