using UnityEngine;

public enum AdResult
{
    FAILD,
    COMPLETED
};

[RequireComponent(typeof(UnityAdsModule))]
[RequireComponent(typeof(AdmobControllerScript))]
[RequireComponent(typeof(FbAudienceModule))]

public class AdvertEngine : MonoBehaviour
{
    public enum AdsTypes
    {
        Banner,
        Interstitial,
        Rewarded
    };

    public enum BannerAdsNetworks
    {
        Unity,
        Admob,
        FBAudience,
        Non
    };

    public enum FullScreenAdsNetworks
    {
        Unity,
        Admob,
        FBAudience,
    };

    public static AdvertEngine Instance;

    //------------------Networks Modules----------------------------------------------------------------------------------------------------------------------------------
    [Header("Modules")]
    [SerializeField] private UnityAdsModule unityAdsModule;
    [SerializeField] private AdmobControllerScript admobAdsModule;
    [SerializeField] private FbAudienceModule fbAudienceAdModule;

    [Header("Ads Loading----------------------------------------------------------"), Space(20)]
    [SerializeField] private bool showBannerOnGameStart = false;
    [SerializeField] private bool loadInterstitialAdsOnStart = false;
    [SerializeField] private bool loadRewardedAdOnStart = false;

    //------------------Networks Modules----------------------------------------------------------------------------------------------------------------------------------

    //------------------Banner Ads priority Setting-----------------------------------------------------------------------------------------------------------------------
    //[Space(20)]
    [Header("Banner Ads Sequence-------------------------------------------------"), Space(10)]
    [SerializeField] private BannerAdsNetworks[] bannerAdsNetworksPeriority;
    [SerializeField] private bool isToReloadBannerOnFailure = true;
    [SerializeField, Range(30, 180)] private int bannerReloadTime = 30;
    [SerializeField] public bool showBannerOnLoad = false;
    private bool isReInvoking = false;
    //------------------Banner Ads priority Setting-----------------------------------------------------------------------------------------------------------------------

    //------------------Interstitial Ads priority Setting-----------------------------------------------------------------------------------------------------------------
    //[Space(20)]
    [Header("Interstitial Ads Sequence"), Space(10)]
    [SerializeField] private FullScreenAdsNetworks[] interstitialAdsNetworkPeriority;
    //------------------Interstitial Ads priority Setting-----------------------------------------------------------------------------------------------------------------

    //------------------Rewarded Ads priority Setting---------------------------------------------------------------------------------------------------------------------
    //[Space(20)]
    [Header("Rewarded Ads Sequence"), Space(10)]
    [SerializeField] private FullScreenAdsNetworks[] rewardedAdsNetworkPeriority;
    //------------------Rewarede Ads priority Setting---------------------------------------------------------------------------------------------------------------------

    //------------------Game over Ads priority Setting---------------------------------------------------------------------------------------------------------------------
    [Header("Game over Ads Preiority---------------------------------------------"), Space(20)]
    public AdsTypes gameOverAdType;
    public FullScreenAdsNetworks[] gameOverNetworksPeriority;
    //------------------Game over Ads priority Setting---------------------------------------------------------------------------------------------------------------------

    //------------------Level completed Ads priority Setting---------------------------------------------------------------------------------------------------------------
    [Header("Level completed Ads Preiority"), Space(10)]
    public AdsTypes levelCompletedAdType;
    public FullScreenAdsNetworks[] LevelCompletedNetworksPeriority;
    //------------------Level completed Ads priority Setting---------------------------------------------------------------------------------------------------------------

    //------------------Game Pause Ads priority Setting--------------------------------------------------------------------------------------------------------------------
    [Header("Game pause Ads Preiority"), Space(10)]
    public AdsTypes gamePauseAdsType;
    public FullScreenAdsNetworks[] gamePauseNetworksPeriority;
    //------------------Game Pause Ads priority Setting--------------------------------------------------------------------------------------------------------------------

    //------------------Game Exit Ads priority Setting---------------------------------------------------------------------------------------------------------------------
    [Header("Game Exit Ads Preiority"), Space(10)]
    public AdsTypes gameExitAdsType;
    public FullScreenAdsNetworks[] gameExitNetworksPeriority;
    //------------------Game Exit Ads priority Setting---------------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (showBannerOnGameStart)
            {
                LoadBannerAds();
            }
            else
            {
                showBannerOnLoad = false;
            }

            if (loadInterstitialAdsOnStart)
            {
                Invoke("LoadInterstitialAds", 0.2f);
            }

            if (loadRewardedAdOnStart)
            {
                Invoke("LoadRewardedAds", 0.3f);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //------------------Banner Ads Controlles-----------------------------------------------------------------------------------------------------------------------------
    #region Banner Ads Controlles
    private int currentlyLoadingBanner = -1;//this status what banner is currently loading if its 0 then its means its is load 1 netwrok banner from periority and vice versa.
    private bool isBannerAdLoad = false;

    public void ShowBannerOnStart()
    {
        showBannerOnLoad = true;
        Invoke("LoadBannerAds", 0.5f);
    }

    public void LoadBannerAds()
    {
        if (isReInvoking)
        {
            CancelInvoke("LoadBannerAds");
            isReInvoking = false;
        }
        currentlyLoadingBanner++;
        if (currentlyLoadingBanner >= bannerAdsNetworksPeriority.Length)
        {
            currentlyLoadingBanner = -1;
            if (isToReloadBannerOnFailure)
            {
                Invoke("LoadBannerAds", bannerReloadTime);
                isReInvoking = true;
                return;
            }
        }
        LoadBannerFromNetwork(bannerAdsNetworksPeriority[currentlyLoadingBanner]);
    }

    public bool IsBannerAdReady()
    {
        return isBannerAdLoad;
    }

    public void ShowBannerAd()
    {
        if (IsBannerAdReady())
        {
            ShowBannerFromNetwork(bannerAdsNetworksPeriority[currentlyLoadingBanner]);
        }
        else
        {
            LoadBannerAds();
            showBannerOnLoad = true;
        }
    }

    public void HideBannerAd()
    {
        HideBannerFromNetwork(bannerAdsNetworksPeriority[currentlyLoadingBanner]);
        currentlyLoadingBanner = -1;
        showBannerOnLoad = false;
    }

    private void LoadBannerFromNetwork(BannerAdsNetworks network)
    {
        switch (network)
        {
            case BannerAdsNetworks.FBAudience:
                fbAudienceAdModule.LoadBannerAd();
                break;
            case BannerAdsNetworks.Admob:
                admobAdsModule.RequestBanner();
                break;
            case BannerAdsNetworks.Unity:
                unityAdsModule.LoadBanner();
                break;
            default:
                break;
        }
    }

    private void ShowBannerFromNetwork(BannerAdsNetworks network)
    {
        StatusShow.instance.ShowAdStatus("**.showing banner: " + network);
        switch (network)
        {
            case BannerAdsNetworks.FBAudience:
                fbAudienceAdModule.ShowBannerAd();
                break;
            case BannerAdsNetworks.Admob:
                admobAdsModule.ShowBanner();
                break;
            case BannerAdsNetworks.Unity:
                unityAdsModule.ShowBannerAd();
                break;
            default:
                break;
        }
    }

    private void HideBannerFromNetwork(BannerAdsNetworks network)
    {
        isBannerAdLoad = false;
        switch (network)
        {
            case BannerAdsNetworks.FBAudience:
                fbAudienceAdModule.HideBannerAd();
                break;
            case BannerAdsNetworks.Admob:
                admobAdsModule.HideBanner();
                break;
            case BannerAdsNetworks.Unity:
                unityAdsModule.HideBannerAd();
                break;
            default:
                break;
        }
    }

    public void BannerAdFaildToLoad()
    {
        StatusShow.instance.ShowAdStatus("**. Banner ad faild at network " + bannerAdsNetworksPeriority[currentlyLoadingBanner]);
        LoadBannerAds();
    }

    public void BannerAdLoadedSuccessfuly()
    {
        StatusShow.instance.ShowAdStatus("**. Banner ad succefuly Loaded at network " + bannerAdsNetworksPeriority[currentlyLoadingBanner]);
        isBannerAdLoad = true;
        if (showBannerOnLoad)
        {
            StatusShow.instance.ShowAdStatus("**. Banner show On Load");
            ShowBannerAd();
        }
    }
    #endregion
    //------------------Banner Ads Controlles-----------------------------------------------------------------------------------------------------------------------------

    //------------------Interstitial Ads Controlles-----------------------------------------------------------------------------------------------------------------------
    #region Interstitial Ads Controlles
    public void LoadInterstitialAds()
    {
        unityAdsModule.LoadVideoAds();
        admobAdsModule.RequestInterstitial();
        fbAudienceAdModule.LoadIntersititialAd();
    }

    public bool IsInterstitialAdReady()
    {
        if (IsInterstitialAdLoadedFromNetwork(interstitialAdsNetworkPeriority[0]) == false)
        {
            if (IsInterstitialAdLoadedFromNetwork(interstitialAdsNetworkPeriority[1]) == false)
            {
                if (IsInterstitialAdLoadedFromNetwork(interstitialAdsNetworkPeriority[0]) == false)
                {
                    StatusShow.instance.ShowAdStatus("**. Non of the networks is was ready....");
                    return false;
                }
                return true;
            }
            return true;
        }
        return true;
    }

    public void ShowInterstitialAd()
    {
        if (ShowInterstitialAdFromNetwork(interstitialAdsNetworkPeriority[0]) == false)
        {
            if (ShowInterstitialAdFromNetwork(interstitialAdsNetworkPeriority[1]) == false)
            {
                if (ShowInterstitialAdFromNetwork(interstitialAdsNetworkPeriority[0]) == false)
                {
                    StatusShow.instance.ShowAdStatus("**. Non of the networks is was ready....");
                    LoadInterstitialAds();
                }
            }
        }
    }

    public void ShowInterstitialAd(FullScreenAdsNetworks[] AdsPerioritiesArray)
    {
        if (ShowInterstitialAdFromNetwork(AdsPerioritiesArray[0]) == false)
        {
            if (ShowInterstitialAdFromNetwork(AdsPerioritiesArray[1]) == false)
            {
                if (ShowInterstitialAdFromNetwork(AdsPerioritiesArray[0]) == false)
                {
                    StatusShow.instance.ShowAdStatus("**. Non of the networks is was ready....");
                    LoadInterstitialAds();
                }
            }
        }
    }

    private bool ShowInterstitialAdFromNetwork(FullScreenAdsNetworks network)
    {
        switch (network)
        {
            case FullScreenAdsNetworks.Unity:
                if (unityAdsModule.IsIntersititialLoaded())
                {
                    unityAdsModule.ShowIntersititialAd();
                    return true;
                }
                else
                {
                    StatusShow.instance.ShowAdStatus("**. unity was not ready....");
                    return false;
                }
            case FullScreenAdsNetworks.Admob:
                if (admobAdsModule.IsIntersititialAdLoaded())
                {
                    admobAdsModule.ShowInterstitial();
                    return true;
                }
                else
                {
                    StatusShow.instance.ShowAdStatus("**. Admob  was not ready....");
                    return false;
                }
            case FullScreenAdsNetworks.FBAudience:
                if (fbAudienceAdModule.IsInterstitialAdLoaded())
                {
                    fbAudienceAdModule.ShowInterstitialAd();
                    return true;
                }
                else
                {
                    StatusShow.instance.ShowAdStatus("**. FB  was not ready....");
                    return false;
                }
            default:
                return false;
        }
    }

    private bool IsInterstitialAdLoadedFromNetwork(FullScreenAdsNetworks network)
    {
        switch (network)
        {
            case FullScreenAdsNetworks.Unity:
                if (unityAdsModule.IsIntersititialLoaded())
                {
                    return true;
                }
                else
                {
                    StatusShow.instance.ShowAdStatus("**. unity was not ready....");
                    return false;
                }
            case FullScreenAdsNetworks.Admob:
                if (admobAdsModule.IsIntersititialAdLoaded())
                {
                    return true;
                }
                else
                {
                    StatusShow.instance.ShowAdStatus("**. Admob  was not ready....");
                    return false;
                }
            case FullScreenAdsNetworks.FBAudience:
                if (fbAudienceAdModule.IsInterstitialAdLoaded())
                {
                    return true;
                }
                else
                {
                    StatusShow.instance.ShowAdStatus("**. FB  was not ready....");
                    return false;
                }
            default:
                StatusShow.instance.ShowAdStatus("**. required network is null....");
                return false;
        }
    }
    #endregion
    //------------------Interstitial Ads Controlles-----------------------------------------------------------------------------------------------------------------------

    //------------------Rewarded Ads Controlles---------------------------------------------------------------------------------------------------------------------------
    #region Rewarded Ads Controlles
    public delegate void OnAdResult();
    private OnAdResult CallBackFunction;
    public void LoadRewardedAds()
    {
        unityAdsModule.LoadVideoAds();
        admobAdsModule.RequesRewardedVideoAd();
        fbAudienceAdModule.LoadRewardedAd();
    }

    public bool IsRewardedAdReady()
    {
        if (IsRewardedAdLoadedFromNetwork(rewardedAdsNetworkPeriority[0]) == false)
        {
            if (IsRewardedAdLoadedFromNetwork(rewardedAdsNetworkPeriority[1]) == false)
            {
                if (IsRewardedAdLoadedFromNetwork(rewardedAdsNetworkPeriority[0]) == false)
                {
                    StatusShow.instance.ShowAdStatus("**. Non of the networks is was ready....");
                    return false;
                }
                return true;
            }
            return true;
        }
        return true;
    }

    public void ShowRewardedAd()
    {
        if (ShowRewardedAdFromNetwork(rewardedAdsNetworkPeriority[0]) == false)
        {
            if (ShowRewardedAdFromNetwork(rewardedAdsNetworkPeriority[1]) == false)
            {
                if (ShowRewardedAdFromNetwork(rewardedAdsNetworkPeriority[0]) == false)
                {
                    StatusShow.instance.ShowAdStatus("**. Non of the networks is was ready....");
                    LoadRewardedAds();
                }
            }
        }
    }

    public void ShowRewardedAd(OnAdResult CallBackFunction)
    {
        this.CallBackFunction = CallBackFunction;
        if (ShowRewardedAdFromNetwork(rewardedAdsNetworkPeriority[0]) == false)
        {
            if (ShowRewardedAdFromNetwork(rewardedAdsNetworkPeriority[1]) == false)
            {
                if (ShowRewardedAdFromNetwork(rewardedAdsNetworkPeriority[0]) == false)
                {
                    StatusShow.instance.ShowAdStatus("**. Non of the networks is was ready....");
                    LoadRewardedAds();
                }
            }
        }
    }

    public void ShowRewardedAd(FullScreenAdsNetworks[] rewardedAdsPeriority)
    {
        if (ShowRewardedAdFromNetwork(rewardedAdsPeriority[0]) == false)
        {
            if (ShowRewardedAdFromNetwork(rewardedAdsPeriority[1]) == false)
            {
                if (ShowRewardedAdFromNetwork(rewardedAdsPeriority[0]) == false)
                {
                    StatusShow.instance.ShowAdStatus("**. Non of the networks is was ready....");
                    LoadRewardedAds();
                }
            }
        }
    }

    public void ShowRewardedAd(FullScreenAdsNetworks[] rewardedAdsPeriority, OnAdResult CallBackFunction)
    {
        this.CallBackFunction = CallBackFunction;
        if (ShowRewardedAdFromNetwork(rewardedAdsPeriority[0]) == false)
        {
            if (ShowRewardedAdFromNetwork(rewardedAdsPeriority[1]) == false)
            {
                if (ShowRewardedAdFromNetwork(rewardedAdsPeriority[0]) == false)
                {
                    StatusShow.instance.ShowAdStatus("**. Non of the networks is was ready....");
                    LoadRewardedAds();
                }
            }
        }
    }

    public void RewardedVideoResult(AdResult result)
    {
        switch (result)
        {
            case AdResult.COMPLETED:
                StatusShow.instance.ShowAdStatus("**. Rewarded Ad compeleted...");
                this.CallBackFunction?.Invoke();
                break;
            case AdResult.FAILD:
                StatusShow.instance.ShowAdStatus("**. Rewarded Ad Faild...");
                break;
        }
    }

    private bool ShowRewardedAdFromNetwork(FullScreenAdsNetworks network)
    {
        switch (network)
        {
            case FullScreenAdsNetworks.Unity:
                if (unityAdsModule.IsRewardedAdLoaded())
                {
                    unityAdsModule.ShoRewardedAd();
                    return true;
                }
                else
                {
                    StatusShow.instance.ShowAdStatus("**. unity was not ready....");
                    return false;
                }
            case FullScreenAdsNetworks.Admob:
                if (admobAdsModule.IsRewardedAdLoaded())
                {
                    admobAdsModule.ShowRewardedAd();
                    return true;
                }
                else
                {
                    StatusShow.instance.ShowAdStatus("**. Admob  was not ready....");
                    return false;
                }
            case FullScreenAdsNetworks.FBAudience:
                if (fbAudienceAdModule.IsRewardedAdLoaded())
                {
                    fbAudienceAdModule.ShowRewardedAd();
                    return true;
                }
                else
                {
                    StatusShow.instance.ShowAdStatus("**. FB  was not ready....");
                    return false;
                }
            default:
                StatusShow.instance.ShowAdStatus("**. required network was null");
                return false;
        }
    }

    private bool IsRewardedAdLoadedFromNetwork(FullScreenAdsNetworks network)
    {
        switch (network)
        {
            case FullScreenAdsNetworks.Unity:
                if (unityAdsModule.IsRewardedAdLoaded())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case FullScreenAdsNetworks.Admob:
                if (admobAdsModule.IsRewardedAdLoaded())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case FullScreenAdsNetworks.FBAudience:
                if (fbAudienceAdModule.IsRewardedAdLoaded())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return false;
        }
    }

    #endregion
    //------------------Rewarded Ads Controlles---------------------------------------------------------------------------------------------------------------------------

    //------------------Game Over Ads Controlles---------------------------------------------------------------------------------------------------------------------------
    #region Game Over
    public void ShowGameOverAd(OnAdResult callBackFunction)
    {
        this.CallBackFunction = callBackFunction;
        switch (gameOverAdType)
        {
            case AdsTypes.Interstitial:
                ShowInterstitialAd(gameOverNetworksPeriority);
                break;
            case AdsTypes.Rewarded:
                ShowRewardedAd(gameOverNetworksPeriority);
                break;
            default:
                ShowBannerAd();
                break;
        }
    }
    public void ShowGameOverAd()
    {
        switch (gameOverAdType)
        {
            case AdsTypes.Interstitial:
                ShowInterstitialAd(gameOverNetworksPeriority);
                break;
            case AdsTypes.Rewarded:
                ShowRewardedAd(gameOverNetworksPeriority);
                break;
            default:
                ShowBannerAd();
                break;
        }
    }
    #endregion
    //------------------Game Over Ads Controlles---------------------------------------------------------------------------------------------------------------------------

    //------------------Game Over Ads Controlles---------------------------------------------------------------------------------------------------------------------------
    #region Level Completed
    public void ShowLevelCompletedAd()
    {
        switch (levelCompletedAdType)
        {
            case AdsTypes.Interstitial:
                ShowInterstitialAd(LevelCompletedNetworksPeriority);
                break;
            case AdsTypes.Rewarded:
                ShowRewardedAd(LevelCompletedNetworksPeriority);
                break;
            default:
                ShowBannerAd();
                break;
        }
    }

    public void ShowLevelCompletedAd(OnAdResult callBackFunction)
    {
        this.CallBackFunction = callBackFunction;
        switch (levelCompletedAdType)
        {
            case AdsTypes.Interstitial:
                ShowInterstitialAd(LevelCompletedNetworksPeriority);
                break;
            case AdsTypes.Rewarded:
                ShowRewardedAd(LevelCompletedNetworksPeriority);
                break;
            default:
                ShowBannerAd();
                break;
        }
    }
    #endregion
    //------------------Game Over Ads Controlles---------------------------------------------------------------------------------------------------------------------------

    //------------------Game Over Ads Controlles---------------------------------------------------------------------------------------------------------------------------
    #region Game Pause
    public void ShowGamePauseAd()
    {
        switch (gamePauseAdsType)
        {
            case AdsTypes.Interstitial:
                ShowInterstitialAd(gamePauseNetworksPeriority);
                break;
            case AdsTypes.Rewarded:
                ShowRewardedAd(gamePauseNetworksPeriority);
                break;
            default:
                ShowBannerAd();
                break;
        }
    }

    public void ShowGamePauseAd(OnAdResult callBackFunction)
    {
        this.CallBackFunction = callBackFunction;
        switch (gamePauseAdsType)
        {
            case AdsTypes.Interstitial:
                ShowInterstitialAd(gamePauseNetworksPeriority);
                break;
            case AdsTypes.Rewarded:
                ShowRewardedAd(gamePauseNetworksPeriority);
                break;
            default:
                ShowBannerAd();
                break;
        }
    }

    #endregion
    //------------------Game Over Ads Controlles---------------------------------------------------------------------------------------------------------------------------

    //------------------Game Over Ads Controlles---------------------------------------------------------------------------------------------------------------------------
    #region Game Exit
    public void ShowGameExitAd()
    {
        switch (gameExitAdsType)
        {
            case AdsTypes.Interstitial:
                ShowInterstitialAd(gameExitNetworksPeriority);
                break;
            case AdsTypes.Rewarded:
                ShowRewardedAd(gameExitNetworksPeriority);
                break;
            default:
                ShowBannerAd();
                break;
        }
    }
    public void ShowGameExitAd(OnAdResult callBackFunction)
    {
        this.CallBackFunction = callBackFunction;
        switch (gameExitAdsType)
        {
            case AdsTypes.Interstitial:
                ShowInterstitialAd(gameExitNetworksPeriority);
                break;
            case AdsTypes.Rewarded:
                ShowRewardedAd(gameExitNetworksPeriority);
                break;
            default:
                ShowBannerAd();
                break;
        }
    }
    #endregion
    //------------------Game Over Ads Controlles---------------------------------------------------------------------------------------------------------------------------

}
