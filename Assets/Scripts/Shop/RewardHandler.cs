using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RewardHandler : MonoBehaviour, IItemPurchase
{
    [SerializeField] Button RemoveAdsBtn;
    [SerializeField] Button SmallPackBtn;
    [SerializeField] Button LargePackBtn;
    [SerializeField] Button SpecialPackBtn;
    [SerializeField] AdSystem AdSystem;
    [SerializeField] RewardGranted RewardGranted;
    [SerializeField] IAPShop IAPShop;
    public UnityEvent UpdateRewards;
    //[SerializeField] IAPItem IAPItem;
    private void Start()
    {
        RemoveAdsBtn.onClick.AddListener(RemoveAds);
        SmallPackBtn.onClick.AddListener(SmallCoinPack);
        LargePackBtn.onClick.AddListener(LargeCoinPack);
        SpecialPackBtn.onClick.AddListener(SpecialCoinPack);

    }
    void PurchaseFail(IAPItem iAPItem)
    {
        
    }
    void RemoveAds()
    {
        IAPShop.PurchaseItemWithId(IAPShop.RewardItems[0].SKU, this);
    }
    void SmallCoinPack()
    {
        IAPShop.PurchaseItemWithId(IAPShop.RewardItems[1].SKU, this);
    }
    void LargeCoinPack()
    {
        IAPShop.PurchaseItemWithId(IAPShop.RewardItems[2].SKU, this);
    }
    void SpecialCoinPack()
    {
        IAPShop.PurchaseItemWithId(IAPShop.RewardItems[3].SKU, this);
    }

    public void PurchaseSuccess(IAPItem iAPItem)
    {
        foreach (var pair in iAPItem.Rewards)
        {
            if(pair.RewardType == RewardType.Coins)
            {
                RewardGranted.NoOfCoins += pair.Amount;
            }
            else if(pair.RewardType == RewardType.Skips)
            {
                RewardGranted.NoOfSkips += pair.Amount;
            }
            else if(pair.RewardType == RewardType.RemoveAds)
            {
                RewardGranted.RemoveAds = true;
            }
        }
        UpdateRewards.Invoke();
    }

    void IItemPurchase.PurchaseFail(IAPItem iAPItem)
    {
        throw new System.NotImplementedException();
    }
}
