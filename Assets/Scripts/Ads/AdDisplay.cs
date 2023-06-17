using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplay : MonoBehaviour, IUnityAdsInitializationListener
{
    public string myGameIdAndroid = "5280809";
    public string myGameIdIOS = "5280808";

    public string adUnitIdAndroid = "Interstitial_Android";
    public string adUnitIdIOS = "Interstitial_iOS";

    public string myAdUnitId;
    public bool initError = false;
    private bool testMode = false;



    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(myGameIdAndroid, testMode, this);
        myAdUnitId = adUnitIdAndroid;
        initError = false;
    }

    public void OnInitializationComplete() 
    {
        Debug.Log("Unity Ads initialization complete.");
        initError = false;
    }

    public void  OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        initError = true;
        Debug.Log(message);
    }


}