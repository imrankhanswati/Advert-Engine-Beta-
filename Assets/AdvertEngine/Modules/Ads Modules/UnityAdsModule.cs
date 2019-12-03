using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class UnityAdsModule : MonoBehaviour
{
    [Header("Unity Ads Controles")]
    [SerializeField] private string unityAdsId = "";

    [Space(20), Header("Unity Ads Controles")]
    [SerializeField] private bool showTestAd = true;

    [Space(20), Header("Unity Ads Placement")]
    [SerializeField] private string bannerAdPlacement = "";
    [SerializeField] private string intersititialAdPlacement = "";
    [SerializeField] private string rewardedAdPlacement = "";

    [Space(20), Header("Banner Ad Placement settings")]
    public BannerPosition bannerPosition;

    public void InitBanner()
    {
        Advertisement.Initialize(unityAdsId, showTestAd);
    }

    public void InitVideoAds()
    {
        Monetization.Initialize(unityAdsId, showTestAd);
    }
    //---------------------------------------Unity Banner Ad controlles-------------------------------------------------------------------------------------------
    #region Banner Ad Controles
    public bool IsBannerAdLoaded()
    {
        StatusShow.instance.ShowAdStatus("banner avalibility :" + Advertisement.Banner.isLoaded);
        return Advertisement.Banner.isLoaded;
    }

    public void LoadBanner()
    {
        if (Advertisement.isInitialized == false)
        {
            Advertisement.Initialize(unityAdsId, showTestAd);
        }
        BannerLoadOptions options = new BannerLoadOptions { loadCallback = OnLoadBannerSuccess, errorCallback = OnLoadBannerFail };
        Advertisement.Banner.Load(bannerAdPlacement, options);
    }

    public void LoadVideoAds()
    {
        if (Monetization.isInitialized == false)
        {
            Monetization.Initialize(unityAdsId, showTestAd);
        }
    }

    public void ShowBannerAd()
    {
        if (Advertisement.Banner.isLoaded == false)
        {
            BannerLoadOptions options = new BannerLoadOptions { loadCallback = OnLoadBannerSuccess, errorCallback = OnLoadBannerFail };
            Advertisement.Banner.SetPosition(bannerPosition);
            Advertisement.Banner.Load(bannerAdPlacement, options);
        }
        else
        {
            BannerOptions options = new BannerOptions { showCallback = OnShowBanner, hideCallback = OnHideBanner };
            Advertisement.Banner.SetPosition(bannerPosition);
            Advertisement.Banner.Show(bannerAdPlacement, options);
        }
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    private void OnLoadBannerSuccess()
    {
        StatusShow.instance.ShowAdStatus("Banner loaded Successfuly");
        AdvertEngine.Instance.BannerAdLoadedSuccessfuly();
        BannerOptions options = new BannerOptions { showCallback = OnShowBanner, hideCallback = OnHideBanner };
    }

    private void OnLoadBannerFail(string message)
    {
        StatusShow.instance.ShowAdStatus("Banner load faild");
        AdvertEngine.Instance.BannerAdFaildToLoad();
    }

    private void OnShowBanner()
    {
        StatusShow.instance.ShowAdStatus("Showing Unity banner");
    }

    private void OnHideBanner()
    {
        StatusShow.instance.ShowAdStatus("Hiding Unity banner");
    }
    #endregion
    //---------------------------------------Unity Banner Ad controlles-------------------------------------------------------------------------------------------

    //---------------------------------------Unity Intersititial Ad controlles------------------------------------------------------------------------------------
    #region Intersitial Ad Controles

    public bool IsIntersititialLoaded()
    {
        StatusShow.instance.ShowAdStatus("intersititial avalibility :" + Monetization.IsReady(intersititialAdPlacement));
        return Monetization.IsReady(intersititialAdPlacement);
    }

    public bool ShowIntersititialAd()
    {
        if (Monetization.IsReady(intersititialAdPlacement))
        {
            ShowAdPlacementContent intersititialAd = Monetization.GetPlacementContent(intersititialAdPlacement) as ShowAdPlacementContent;
            if (intersititialAd != null)
            {
                intersititialAd.Show();
                StatusShow.instance.ShowAdStatus("showing intersititial ad");
                return true;
            }
        }
        else
        {
            StatusShow.instance.ShowAdStatus("intersititial was not loaded");
            return false;
        }
        return false;
    }
    #endregion
    //---------------------------------------Unity Intersititial Ad controlles------------------------------------------------------------------------------------

    //---------------------------------------Unity Rewarded Ad controlles-----------------------------------------------------------------------------------------
    #region Rewarded Ad Controles

    public bool IsRewardedAdLoaded()
    {
        StatusShow.instance.ShowAdStatus("rewarded avalibility :" + Monetization.IsReady(intersititialAdPlacement));
        return Monetization.IsReady(rewardedAdPlacement);
    }

    public bool ShoRewardedAd()
    {
        if (Monetization.IsReady(rewardedAdPlacement))
        {
            ShowAdPlacementContent rewardedAd = Monetization.GetPlacementContent(rewardedAdPlacement) as ShowAdPlacementContent;
            if (rewardedAd != null)
            {
                rewardedAd.Show(RewardedAdCompletionCallBack);
                StatusShow.instance.ShowAdStatus("showing rewarded ad");
                return true;
            }
        }
        else
        {
            StatusShow.instance.ShowAdStatus("rewarded was not loaded");
            return false;
        }
        return false;
    }

    public void RewardedAdCompletionCallBack(UnityEngine.Monetization.ShowResult rewardedResult)
    {
        switch (rewardedResult)
        {
            case UnityEngine.Monetization.ShowResult.Finished:
                AdvertEngine.Instance.RewardedVideoResult(AdResult.COMPLETED);
                break;
            case UnityEngine.Monetization.ShowResult.Skipped:
                AdvertEngine.Instance.RewardedVideoResult(AdResult.FAILD);
                break;
            default:
                AdvertEngine.Instance.RewardedVideoResult(AdResult.FAILD);
                break;
        }
    }
    #endregion
    //---------------------------------------Unity Rewarded Ad controlles-----------------------------------------------------------------------------------------
}
