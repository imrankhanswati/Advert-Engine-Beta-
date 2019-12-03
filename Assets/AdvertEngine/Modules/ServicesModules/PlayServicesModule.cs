using UnityEngine;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;

public class PlayServicesModule : MonoBehaviour
{
    //[SerializeField] private bool AutoBuildEnabled = true;
    //[SerializeField] private bool AutoSignIn = true;

    //private bool isPlayServicesActivated = false;

    //private void Start()
    //{
    //    if (AutoBuildEnabled)
    //    {
    //        isPlayServicesActivated = ActivatePlayeServices();
    //    }
    //    if (AutoSignIn)
    //    {
    //        SignIn();
    //    }
    //}

    ////-------------------------------Play services Activation and Controlles----------------------------------------------------------------------------------------
    //#region Play services Activation and Controlles
    //public bool ActivatePlayeServices()
    //{
    //    if (IsInternetAvaliable())
    //    {
    //        PlayGamesClientConfiguration clientConfig = new PlayGamesClientConfiguration.Builder().Build();
    //        PlayGamesPlatform.InitializeInstance(clientConfig);
    //        PlayGamesPlatform.Activate();

    //        StatusShow.instance.ShowAdStatus("Play services activated...");

    //        return true;
    //    }
    //    else
    //    {
    //        StatusShow.instance.ShowAdStatus("Play services faild to activate...");
    //        return false;
    //    }
    //}

    //public bool SignIn()
    //{
    //    bool returnState = false;
    //    if (isPlayServicesActivated)
    //    {
    //        if (!Social.localUser.authenticated)
    //        {
    //            Social.localUser.Authenticate((bool success) =>
    //            {
    //                if (success)
    //                {
    //                    returnState = true;
    //                }
    //                else
    //                {
    //                    returnState = false;
    //                }
    //            });
    //        }
    //        else
    //        {
    //            StatusShow.instance.ShowAdStatus("Already Signined....");
    //        }
    //    }
    //    else
    //    {
    //        isPlayServicesActivated = ActivatePlayeServices();
    //        if (isPlayServicesActivated)
    //        {
    //            if (!Social.localUser.authenticated)
    //            {
    //                Social.localUser.Authenticate((bool success) =>
    //                {
    //                    if (success)
    //                    {
    //                        returnState = true;
    //                    }
    //                    else
    //                    {
    //                        returnState = false;
    //                    }
    //                });
    //            }
    //            else
    //            {
    //                StatusShow.instance.ShowAdStatus("Already Signined....");
    //            }
    //        }
    //        else
    //        {
    //            returnState = false;
    //        }
    //    }

    //    if (returnState)
    //    {
    //        StatusShow.instance.ShowAdStatus("Sigin in successful");
    //    }
    //    else
    //    {
    //        StatusShow.instance.ShowAdStatus("Sigin in faild");
    //    }
    //    return returnState;
    //}

    //public bool SignOut()
    //{
    //    if (Social.localUser.authenticated)
    //    {
    //        PlayGamesPlatform.Instance.SignOut();
    //        StatusShow.instance.ShowAdStatus("Signed out....");
    //    }
    //    else
    //    {
    //        StatusShow.instance.ShowAdStatus("Already Signined Out....");
    //    }
    //    return true;
    //}
    //#endregion
    ////-------------------------------Play services Activation and Controlles----------------------------------------------------------------------------------------

    ////-------------------------------Acheivements-------------------------------------------------------------------------------------------------------------------
    //#region Acheivements
    //public bool ShowAchevements()
    //{
    //    if (Social.localUser.authenticated)
    //    {
    //        Social.ShowAchievementsUI();
    //        return true;
    //    }
    //    else
    //    {
    //        if (SignIn())
    //        {
    //            Social.ShowAchievementsUI();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}

    //public bool ReportAchevementProgress(string achevementId, double progress)
    //{
    //    bool returnState = false;

    //    if (Social.localUser.authenticated)
    //    {
    //        Social.ReportProgress(achevementId, progress,
    //            (bool success) =>
    //            {
    //                if (success)
    //                {
    //                    returnState = true;
    //                }
    //                else
    //                {
    //                    returnState = false;
    //                }
    //            });
    //    }
    //    else
    //    {
    //        if (SignIn())
    //        {
    //            Social.ReportProgress(achevementId, progress,
    //            (bool success) =>
    //            {
    //                if (success)
    //                {
    //                    returnState = true;
    //                }
    //                else
    //                {
    //                    returnState = false;
    //                }
    //            });
    //        }
    //        else
    //        {
    //            returnState = false;
    //        }
    //    }
    //    return returnState;
    //}

    //public bool ReportAchevement(string achevementId)
    //{
    //    bool returnState = false;

    //    if (Social.localUser.authenticated)
    //    {
    //        Social.ReportProgress(achevementId, 1,
    //            (bool success) =>
    //            {
    //                if (success)
    //                {
    //                    returnState = true;
    //                }
    //                else
    //                {
    //                    returnState = false;
    //                }
    //            });
    //    }
    //    else
    //    {
    //        if (SignIn())
    //        {
    //            Social.ReportProgress(achevementId, 1,
    //            (bool success) =>
    //            {
    //                if (success)
    //                {
    //                    returnState = true;
    //                }
    //                else
    //                {
    //                    returnState = false;
    //                }
    //            });
    //        }
    //        else
    //        {
    //            returnState = false;
    //        }
    //    }
    //    return returnState;
    //}
    //#endregion
    ////-------------------------------Acheivements-------------------------------------------------------------------------------------------------------------------

    ////-------------------------------Leader Board-------------------------------------------------------------------------------------------------------------------
    //#region LeaderBoard
    //public bool ShowLeaderBoard()
    //{
    //    if (Social.localUser.authenticated)
    //    {
    //        Social.ShowLeaderboardUI();
    //        return true;
    //    }
    //    else
    //    {
    //        if (SignIn())
    //        {
    //            Social.ShowLeaderboardUI();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}

    //public bool ReportLeaderBoard(string leaderBoardId, long reporteValue)
    //{
    //    bool returnState = false;
    //    if (Social.localUser.authenticated)
    //    {
    //        PlayGamesPlatform.Instance.ReportScore(reporteValue, leaderBoardId,
    //            (bool success) =>
    //            {
    //                if (success)
    //                {
    //                    returnState = true;
    //                }
    //                else
    //                {
    //                    returnState = false;
    //                }
    //            });
    //    }
    //    else
    //    {
    //        if (SignIn())
    //        {
    //            PlayGamesPlatform.Instance.ReportScore(reporteValue, leaderBoardId,
    //            (bool success) =>
    //            {
    //                if (success)
    //                {
    //                    returnState = true;
    //                }
    //                else
    //                {
    //                    returnState = false;
    //                }
    //            });
    //        }
    //        else
    //        {
    //            returnState = false;
    //        }
    //    }
    //    return returnState;
    //}
    //#endregion
    ////-------------------------------Leader Board-------------------------------------------------------------------------------------------------------------------

    //private bool IsInternetAvaliable()
    //{
    //    if (Application.internetReachability == NetworkReachability.NotReachable)
    //    {
    //        StatusShow.instance.ShowAdStatus("No Internet Connection");
    //        return false;
    //    }
    //    else
    //    {
    //        StatusShow.instance.ShowAdStatus("Internet Conncection Successful");
    //        return true;
    //    }
    //}
}
