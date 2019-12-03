#define TapJoy_Ads_Interstitial
#define TapJoy_Ads_Rewarded
#define TapJoy_Ads_OfferWall


using UnityEngine;
//using TapjoyUnity;


public class TapjoyController : MonoBehaviour
{

    //[Header("Sdk Key")]
    //[SerializeField] private string sdkKey;

    //[Space(20), Header("Placement Strings")]
    //[SerializeField] private string interstitialAdPlacementString;
    //[SerializeField] private string offerWallAdPlacementString;
    //[SerializeField] private string rewardedAdPlacementString;

    //[Space(20), Header("Placements Loading behavior")]
    //[SerializeField] private bool loadIntersitialOnConnect = false;
    //[SerializeField] private bool loadOfferWallOnConnect = false;
    //[SerializeField] private bool loadRewardedOnConnect = false;

    //private TJPlacement intersititialPlacment;
    //private TJPlacement offerWallPlacement;
    //private TJPlacement rewardedPlacement;

    //public void OnEnable()
    //{
    //    TJPlacement.OnRequestSuccess += HandlePlacementRequestSuccess;
    //    TJPlacement.OnRequestFailure += HandlePlacementRequestFailure;
    //    TJPlacement.OnContentReady += HandlePlacementContentReady;
    //    TJPlacement.OnContentShow += HandlePlacementContentShow;
    //    TJPlacement.OnContentDismiss += HandlePlacementContentDismiss;

    //    Tapjoy.OnGetCurrencyBalanceResponse += HandleGetCurrencyBalanceResponse;
    //    Tapjoy.OnGetCurrencyBalanceResponseFailure += HandleGetCurrencyBalanceResponseFailure;

    //    Tapjoy.OnEarnedCurrency += HandleEarnedCurrency;

    //    Tapjoy.OnAwardCurrencyResponse += HandleAwardCurrencyResponse;
    //    Tapjoy.OnAwardCurrencyResponseFailure += HandleAwardCurrencyResponseFailure;
    //}

    //public void OnDisable()
    //{
    //    TJPlacement.OnRequestSuccess -= HandlePlacementRequestSuccess;
    //    TJPlacement.OnRequestFailure -= HandlePlacementRequestFailure;
    //    TJPlacement.OnContentReady -= HandlePlacementContentReady;
    //    TJPlacement.OnContentShow -= HandlePlacementContentShow;
    //    TJPlacement.OnContentDismiss -= HandlePlacementContentDismiss;

    //    Tapjoy.OnGetCurrencyBalanceResponse -= HandleGetCurrencyBalanceResponse;
    //    Tapjoy.OnGetCurrencyBalanceResponseFailure -= HandleGetCurrencyBalanceResponseFailure;

    //    Tapjoy.OnEarnedCurrency -= HandleEarnedCurrency;

    //    Tapjoy.OnAwardCurrencyResponse -= HandleAwardCurrencyResponse;
    //    Tapjoy.OnAwardCurrencyResponseFailure -= HandleAwardCurrencyResponseFailure;
    //}
    ////---------------------------------Tap Joy Connection----------------------------------------------------------------------------------------
    //#region Tap joy Connection
    //public void StartTapjoy()
    //{
    //    if (Tapjoy.IsConnected == false)
    //    {
    //        Tapjoy.Connect(sdkKey);
    //        Tapjoy.OnConnectSuccess += TapjoyConnectionSuccess;
    //        Tapjoy.OnConnectFailure += TapjoyConnectionFaild;
    //    }
    //    else
    //    {
    //        StatusShow.instance.ShowAdStatus("Tapjoy already connected...");
    //    }
    //}

    //private void TapjoyConnectionSuccess()
    //{
    //    if (intersititialPlacment == null && loadIntersitialOnConnect)
    //    {
    //        intersititialPlacment = TJPlacement.CreatePlacement(interstitialAdPlacementString);
    //        intersititialPlacment.RequestContent();
    //    }

    //    if (offerWallPlacement == null && loadOfferWallOnConnect)
    //    {
    //        offerWallPlacement = TJPlacement.CreatePlacement(offerWallAdPlacementString);
    //        offerWallPlacement.RequestContent();
    //    }

    //    if (rewardedPlacement == null && loadRewardedOnConnect)
    //    {
    //        rewardedPlacement = TJPlacement.CreatePlacement(rewardedAdPlacementString);
    //        rewardedPlacement.RequestContent();
    //    }
    //    StatusShow.instance.ShowAdStatus("Tapjoy connection Successeded...");
    //}

    //private void TapjoyConnectionFaild()
    //{
    //    StatusShow.instance.ShowAdStatus("Tapjoy connection faild...");
    //}

    //private void ConnectTapjoy()
    //{
    //    StartTapjoy();
    //}
    //#endregion
    ////---------------------------------Tap Joy Connection----------------------------------------------------------------------------------------

    ////---------------------------------Tap Joy Interstitial--------------------------------------------------------------------------------------
    //#region Tap Joy Interstitial
    //private bool IsIntersititialReady()
    //{
    //    if (Tapjoy.IsConnected)
    //    {
    //        if (intersititialPlacment.IsContentReady())
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        ConnectTapjoy();
    //        StatusShow.instance.ShowAdStatus("Tapjoy was not connected... connecting again");
    //        return false;
    //    }
    //}

    //public void ShowIntersitial()
    //{
    //    if (IsIntersititialReady())
    //    {
    //        intersititialPlacment.ShowContent();
    //    }
    //    else
    //    {
    //        StatusShow.instance.ShowAdStatus("Tapjoy has faild to shown intersitial");
    //    }
    //}
    //#endregion
    ////---------------------------------Tap Joy Interstitial--------------------------------------------------------------------------------------

    ////---------------------------------Tap Joy Rewarded------------------------------------------------------------------------------------------
    //#region Tap joy Rewarded
    //private bool IsRewardedVideoReady()
    //{
    //    if (Tapjoy.IsConnected)
    //    {
    //        if (rewardedPlacement.IsContentReady())
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        ConnectTapjoy();
    //        StatusShow.instance.ShowAdStatus("Tapjoy was not connected... connecting again");
    //        return false;
    //    }
    //}

    //public void ShowRewardedVideo()
    //{
    //    if (IsRewardedVideoReady())
    //    {
    //        rewardedPlacement.ShowContent();
    //    }
    //    else
    //    {
    //        StatusShow.instance.ShowAdStatus("Tapjoy has faild to shown rewarded");
    //    }
    //}
    //#endregion
    ////---------------------------------Tap Joy Rewarded------------------------------------------------------------------------------------------

    ////---------------------------------Tap Joy Offer Wall----------------------------------------------------------------------------------------
    //#region Tap joy Offer Wall
    //private bool IsOfferWallReady()
    //{
    //    if (Tapjoy.IsConnected)
    //    {
    //        if (offerWallPlacement.IsContentReady())
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        ConnectTapjoy();
    //        StatusShow.instance.ShowAdStatus("Tapjoy was not connected... connecting again");
    //        return false;
    //    }
    //}

    //public void ShowOfferWall()
    //{
    //    if (IsOfferWallReady())
    //    {
    //        offerWallPlacement.ShowContent();
    //    }
    //    else
    //    {
    //        StatusShow.instance.ShowAdStatus("Tapjoy has faild to shown offer wall");
    //    }
    //}
    //#endregion
    ////---------------------------------Tap Joy Offer Wall----------------------------------------------------------------------------------------

    ////---------------------------------Tap Joy Events Handler------------------------------------------------------------------------------------
    //#region TapJoy Event Handler
    //public void HandlePlacementRequestSuccess(TJPlacement placement)
    //{
    //    StatusShow.instance.ShowAdStatus(placement.GetName() + " request success.");
    //}

    //public void HandlePlacementRequestFailure(TJPlacement placement, string error)
    //{
    //    StatusShow.instance.ShowAdStatus(placement.GetName() + " Request Faild.");
    //}

    //public void HandlePlacementContentReady(TJPlacement placement)
    //{
    //    StatusShow.instance.ShowAdStatus(placement.GetName() + " Ready.");
    //}

    //public void HandlePlacementContentShow(TJPlacement placement)
    //{
    //    StatusShow.instance.ShowAdStatus(placement.GetName() + " Shown.");
    //}

    //public void HandlePlacementContentDismiss(TJPlacement placement)
    //{
    //    StatusShow.instance.ShowAdStatus(placement.GetName() + " Dismissed.");
    //    Tapjoy.GetCurrencyBalance();
    //    if(placement.GetName() == rewardedAdPlacementString)
    //    {
    //        StatusShow.instance.ShowAdStatus("Rewarded Ad completed.");
    //    }
    //    placement.RequestContent();
    //}

    //public void HandleGetCurrencyBalanceResponse(string currencyName, int balance)
    //{
    //    StatusShow.instance.ShowAdStatus("HandleGetCurrencyBalanceResponse: currencyName: " + currencyName + ", balance: " + balance);
    //}

    //public void HandleGetCurrencyBalanceResponseFailure(string error)
    //{
    //    StatusShow.instance.ShowAdStatus("HandleGetCurrencyBalanceResponseFailure: " + error);
    //}

    //public void HandleEarnedCurrency(string currencyName, int amount)
    //{
    //    StatusShow.instance.ShowAdStatus("HandleEarnedCurrency: currencyName: " + currencyName + ", amount: " + amount);
    //}

    //public void HandleAwardCurrencyResponse(string currencyName, int balance)
    //{
    //    Debug.Log("C#: HandleAwardCurrencySucceeded: currencyName: " + currencyName + ", balance: " + balance);
    //    StatusShow.instance.ShowAdStatus("HandleAwardCurrencySucceeded: currencyName: " + currencyName + ", balance: " + balance);
    //}

    //public void HandleAwardCurrencyResponseFailure(string error)
    //{
    //    Debug.Log("C#: HandleAwardCurrencyResponseFailure: " + error);
    //    StatusShow.instance.ShowAdStatus("HandleAwardCurrencyResponseFailure: " + error);
    //}
    //#endregion
    ////---------------------------------Tap Joy Events Handler------------------------------------------------------------------------------------

}
