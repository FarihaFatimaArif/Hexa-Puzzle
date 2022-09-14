using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObject/AdSystemSO", order = 1, fileName = "AdSystem")]
public class AdSystem : ScriptableObject
{
    [SerializeField] RewardGranted RewardGranted;
    private const string MaxKey = "hlKffQFn1sKXRefAUUKG4o-i-OOURETonfImCKvE29oyDwftIiyhVZMlNNxwUFl8NgUmynX33XOEq5m09yb34Z";
    private const string RewardedAdUnit = "585f249ad115c420";
    private const string InterstitialAdUnit = "7d62e5180461f57a";
    private const string BannerAdUnit = "b56d58800dadb2d1";
    // bool counter = true;
    float startTime;
    float endTime;
    float difference;
    public UnityAction RewardAction;
    public UnityEvent RewardedAdDone;
    //public UnityEvent ExitedAdDone;
    public void InitializingAdSystem()
    {
        startTime = Time.time;
        //difference = 30;
        Debug.Log("here");
        IntializingSdk();
        MaxSdk.LoadInterstitial(InterstitialAdUnit);
        MaxSdk.LoadRewardedAd(RewardedAdUnit);
        //StartCoroutine(Counter());
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialsAdClosed;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdClosed;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;
       // MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailed;

    }
    void OnInterstitialsAdClosed(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        startTime = Time.time;
        MaxSdk.LoadInterstitial(InterstitialAdUnit);
        Debug.Log("here");
    }
    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        startTime = Time.time;
        if (RewardAction != null)
        {
            RewardAction();
        }
    }

    void OnRewardedAdClosed(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        startTime = Time.time;
        MaxSdk.LoadRewardedAd(RewardedAdUnit);
    }
        public void IntializingSdk()
    {
        string[] adUnitIds = {
            // rewarded
            RewardedAdUnit,
            // interstitial
            InterstitialAdUnit,
            // banner
            BannerAdUnit
        };
        MaxSdk.SetSdkKey(MaxKey);
        MaxSdk.SetUserId(SystemInfo.deviceUniqueIdentifier);
        MaxSdk.SetVerboseLogging(true);
        MaxSdkCallbacks.OnSdkInitializedEvent += OnMaxInitialized;
        MaxSdk.InitializeSdk(adUnitIds);

    }
    private void OnMaxInitialized(MaxSdkBase.SdkConfiguration sdkConfiguration)
    {
        if (MaxSdk.IsInitialized())
        {
#if DEVELOPMENT_BUILD || UNITY_EDITOR
            MaxSdk.ShowMediationDebugger();
#endif
            Debug.Log("MaxSDK initialized");
        }
        else
        {
            Debug.Log("Failed to init MaxSDK");
        }
    }

    public void OnQuitAd()
    {
        if(MaxSdk.IsInitialized() && Counter()==true && RewardGranted.RemoveAds!=true)
        {
            if (MaxSdk.IsInterstitialReady(InterstitialAdUnit))
            {
                MaxSdk.ShowInterstitial(InterstitialAdUnit);
            }
        }
        startTime = Time.time;
       // ExitedAdDone.Invoke();
    }
    public void OnRewardAd()
    {
        if (MaxSdk.IsInitialized())
        {
            if (RewardGranted.NoOfSkips == 0)
            {
                if (MaxSdk.IsRewardedAdReady(RewardedAdUnit))
                {
                    MaxSdk.ShowRewardedAd(RewardedAdUnit);
                }
            }
            else
            {
                if (RewardAction != null)
                {
                    RewardAction();
                }
                RewardGranted.NoOfSkips--;
            }
        }
    }
    //IEnumerator Counter()
    //{
    //    //Print the time of when the function is first called.
    //    Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //    //yield on a new YieldInstruction that waits for 5 seconds.
    //    yield return new WaitForSeconds(30);
    //    counter = true;
    //    //After we have waited 5 seconds print the time again.
    //    Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    //}
    bool Counter()
    {
        endTime = Time.time;
        difference = endTime - startTime;
       if (difference>=30)
        {
            return true;
        }
        return false;
    }
}