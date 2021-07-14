using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string _gameId = "4214979";
    string _myPlacementId = "Rewarded_Android";
    bool _areAdsAvailable;
    public GameObject watchVideoButton;


    void Start()
    {
        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, false);

        _areAdsAvailable = Advertisement.IsReady(_myPlacementId);

        InvokeRepeating("EnableRewardButton", 1f, 10f);
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == _myPlacementId)
        {
            _areAdsAvailable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            //REWARD USER
            InventoryManager.Instance.UpdateGemAmount(100);
            

        }
        else if (showResult == ShowResult.Skipped)
        {

            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(_myPlacementId))
        {
            Advertisement.Show(_myPlacementId);
            _areAdsAvailable = false;
        }
    }


    void EnableRewardButton()
    {
        _areAdsAvailable = Advertisement.IsReady(_myPlacementId);

        if (_areAdsAvailable)
        {
            Debug.Log("Ads are available");
            watchVideoButton.SetActive(true);
        }
            
        else
        {
            Debug.Log("Ads are not available");
            watchVideoButton.SetActive(false);

        }
    }

}
