using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void ShowRewardedAdd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions
            {
                //resultCallback = HandleShowResult
                //Advertisement.AddListener()
            };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    void HandleShowResult(ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                Debug.Log("The Video Failed");
                break;
            case ShowResult.Skipped:
                Debug.Log("You Skipped the Ad Stuff");
                break;
            case ShowResult.Finished:
                //mozo
                break;
            default:
                break;
        }
    }
}
