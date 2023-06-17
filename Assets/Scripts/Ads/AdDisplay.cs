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
    public bool adStarted;

    private bool testMode = false;



    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_IOS
	        Advertisement.Initialize(myGameIdIOS, testMode, this);
	        myAdUnitId = adUnitIdIOS;
        #else
                Advertisement.Initialize(myGameIdAndroid, testMode, this);
                myAdUnitId = adUnitIdAndroid;
        #endif

    }

    public void OnInitializationComplete() {}

    public void  OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log(message);
    }


}