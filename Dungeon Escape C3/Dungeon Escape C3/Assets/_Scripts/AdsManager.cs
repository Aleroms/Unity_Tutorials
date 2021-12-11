using System.Collections;

using UnityEngine;

using UnityEngine.Advertisements;



public class AdsManager : MonoBehaviour, IUnityAdsListener

{
    public Player player;

    string gameId = "4499457"; // get this from your unity dashboard

    //placement = ad Unit ID on Unity's monitization platform
    string placement = "Rewarded_Android";

    bool testMode = true;

    void Start()
    {

        Advertisement.AddListener(this);

        Advertisement.Initialize(gameId, testMode);

    }

    public void ShowAd()
    {

        Advertisement.Show(placement);

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {

        switch (showResult)

        {

            case ShowResult.Finished:
                player.AddGems(100);
                UIManager.Instance.OpenShop(player.diamonds);
                Debug.Log("100 gems awarded to you");
                break;
            case ShowResult.Skipped:
                Debug.Log("You skipped ad no gems awarded to you");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad video failed to play");
                break;

        }

    }

    public void OnUnityAdsDidError(string message)

    {



    }
    public void OnUnityAdsDidStart(string placementId)
    {



    }

    public void OnUnityAdsReady(string placementId)
    {



    }

} // end of AdsManage