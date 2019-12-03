using UnityEngine;
using AudienceNetwork;

[ExecuteInEditMode]
public class FbAudienceModule : MonoBehaviour
{
    [Header("FB Placement Ids")]
    [SerializeField] private string bannerAdId;
    [SerializeField] private string intersititialAdId;
    [SerializeField] private string rewardedAdId;

    [Header("**FB test Ads must be setuped on the console."), Space(20)]
    [Tooltip("*FB audience test ad must be setuped from fb console. this bool value is not going to work..."),SerializeField] private bool testAds = false;

    [Header("Banner View Controller"), Space(20)]
    [SerializeField] private AdPosition bannerAdPosition;
    [SerializeField] private AdSize bannerAdSize;

    //--------------------------Banner Ad Setting And controles-------------------------------------------------------------------------------------
    #region Banner ads Controles
    private AdView bannerAdView;

    public void LoadBannerAd()
    {

        StatusShow.instance.ShowAdStatus("Loading Banner...");
        if (bannerAdView)
        {
            bannerAdView.Dispose();
        }

        bannerAdView = new AdView(bannerAdId, bannerAdSize);
        bannerAdView.Register(gameObject);

        bannerAdView.AdViewDidLoad = delegate ()
        {
            LoadingBannerAdSuccessful();
        };
        bannerAdView.AdViewDidFailWithError = delegate (string error)
        {
            LoadingBannerAdFaild();
        };

        bannerAdView.LoadAd();
    }

    public void ShowBannerAd()
    {
        if (bannerAdView == null)
        {
            LoadBannerAd();
        }
        else
        {
            bannerAdView.Show(bannerAdPosition);
        }
    }

    public void HideBannerAd()
    {
        if (bannerAdView)
        {
            bannerAdView.Dispose();
            bannerAdView = null;
        }
    }

    private void LoadingBannerAdFaild()
    {
        StatusShow.instance.ShowAdStatus("Banner ad faild to laod.");
        AdvertEngine.Instance.BannerAdFaildToLoad();
    }

    private void LoadingBannerAdSuccessful()
    {
        string isAdValid = bannerAdView.IsValid() ? "valid" : "invalid";
        AdvertEngine.Instance.BannerAdLoadedSuccessfuly();
        StatusShow.instance.ShowAdStatus("Banner loaded and is " + isAdValid + ".");
    }
    #endregion
    //--------------------------Banner Ad Setting And controles-------------------------------------------------------------------------------------

    //--------------------------Interstitial Ad Settings and controlles----------------------------------------------------------------------------
    #region Intersititial Ad Controles
    private InterstitialAd interstitialAd;
    private bool isInterstitialAdLoaded = false;
    private bool isInterstitialLoading = false;

    public void LoadIntersititialAd()
    {
        if (isInterstitialLoading)
        {
            return;
        }
        if (isInterstitialAdLoaded)
        {
            return;
        }

        isInterstitialLoading = true;
        isInterstitialAdLoaded = false;

        StatusShow.instance.ShowAdStatus("Loading Interstitial Ad....");
        interstitialAd = new InterstitialAd(intersititialAdId);
        interstitialAd.Register(gameObject);

        interstitialAd.InterstitialAdDidLoad = delegate ()
        {
            LoadingInterstitialAdSuccessful();
        };
        interstitialAd.InterstitialAdDidFailWithError = delegate (string error)
        {
            LoadingInterstitialAdFaild();
        };
        interstitialAd.InterstitialAdDidClose = delegate ()
        {
            InterstitialAdClosed();
        };
        interstitialAd.LoadAd();
    }

    public void ShowInterstitialAd()
    {
        if (isInterstitialAdLoaded)
        {
            isInterstitialAdLoaded = false;
            interstitialAd.Show();
        }
        else
        {
            if (isInterstitialLoading == false)
            {
                LoadIntersititialAd();
            }
        }
    }

    public bool IsInterstitialAdLoaded()
    {
        return isInterstitialAdLoaded;
    }

    private void LoadingInterstitialAdSuccessful()
    {
        isInterstitialLoading = false;
        isInterstitialAdLoaded = true;

        string isAdValid = interstitialAd.IsValid() ? "valid" : "invalid";
        StatusShow.instance.ShowAdStatus("Interstitial Ad loaded and " + isAdValid);
    }

    private void LoadingInterstitialAdFaild()
    {
        isInterstitialLoading = false;
        isInterstitialAdLoaded = false;

        StatusShow.instance.ShowAdStatus("Interstitial Ad faild load");
    }

    private void InterstitialAdClosed()
    {
        isInterstitialAdLoaded = false;
        isInterstitialLoading = false;

        if (interstitialAd != null)
        {
            interstitialAd.Dispose();
        }
        StatusShow.instance.ShowAdStatus("Interstitial Ad Closed");
        LoadIntersititialAd();
    }
    #endregion
    //--------------------------Interstitial Ad Settings and controlles----------------------------------------------------------------------------

    //--------------------------Rewarded Ad Settings and controlles--------------------------------------------------------------------------------
    #region Rewarded video ad Controles
    private RewardedVideoAd rewardedAd;
    private bool isRewardedLoaded = false;
    private bool isRewardedLoading = false;

    public void LoadRewardedAd()
    {
        if (isRewardedLoaded)
        {
            return;
        }

        if (isRewardedLoading)
        {
            return;
        }

        isRewardedLoading = true;
        isRewardedLoaded = false;

        rewardedAd = new RewardedVideoAd(rewardedAdId);
        rewardedAd.Register(gameObject);

        rewardedAd.RewardedVideoAdDidLoad = delegate ()
        {
            LoadingRewardedAdSuccessful();
        };
        rewardedAd.RewardedVideoAdDidFailWithError = delegate (string error)
        {
            LoadingRewardedAdFaild();
        };
        rewardedAd.rewardedVideoAdComplete = delegate ()
        {
            RewardedAdCompleted();
        };

        rewardedAd.LoadAd();
    }

    public bool ShowRewardedAd()
    {
        if (isRewardedLoaded)
        {
            isRewardedLoaded = false;
            rewardedAd.Show();
            return true;
        }
        else
        {
            if (isRewardedLoading == false)
            {
                LoadRewardedAd();
            }
            return false;
        }
    }

    public bool IsRewardedAdLoaded()
    {
        return isRewardedLoaded;
    }

    private void LoadingRewardedAdSuccessful()
    {
        isRewardedLoading = false;
        isRewardedLoaded = true;
        string isAdValid = rewardedAd.IsValid() ? "valid" : "invalid";
        StatusShow.instance.ShowAdStatus("Rewarded ad loaded and " + isAdValid);
    }

    private void LoadingRewardedAdFaild()
    {
        isRewardedLoading = false;
        isRewardedLoaded = false;
        StatusShow.instance.ShowAdStatus("Rewarded ad Faild to load");
    }

    private void RewardedAdCompleted()
    {
        isRewardedLoading = false;
        isRewardedLoaded = false;

        if (rewardedAd != null)
        {
            rewardedAd.Dispose();
        }

        LoadRewardedAd();

        AdvertEngine.Instance.RewardedVideoResult(AdResult.COMPLETED);
    }
    #endregion
    //--------------------------Rewarded Ad Settings and controlles--------------------------------------------------------------------------------

}
