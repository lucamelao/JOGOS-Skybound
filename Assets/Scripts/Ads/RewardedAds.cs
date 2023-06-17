using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private string _androidAdUnitRewardedId = "Rewarded_Android";
    private string _adUnitId = null;
    public AdButton adButton;

    public AdDisplay adDisplay;

    void Awake()
    {
      _adUnitId = _androidAdUnitRewardedId;
    }

    public void LoadAndShowAd()
    {
        if(!adDisplay.intitComplete) 
        {
            adButton.adState = AdState.Skipped;
            return;
        }
        if(adButton.adState != AdState.Watching) return;
        LoadAd();
    }


    void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
        ShowAd();
    }

    void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                adButton.adState = AdState.Completed;
                break;
            case ShowResult.Skipped:
                adButton.adState = AdState.Skipped;
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                adButton.adState = AdState.Skipped;
                Debug.LogError("The ad failed to be shown.");
                break;
        }
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
        adButton.adState = AdState.Skipped;
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        adButton.adState = AdState.Skipped;
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
    }
}