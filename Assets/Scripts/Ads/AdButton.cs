using UnityEngine;
using UnityEngine.UI;

public class AdButton : MonoBehaviour
{
    public RewardedAds rewardedAds; // Reference to the RewardedAds script.

    // Assign this to the Button's onClick event in the inspector.
    public void OnButtonClick()
    {
        // Call the LoadAndShowAd() function in the RewardedAds script.
        rewardedAds.LoadAndShowAd();
    }
}