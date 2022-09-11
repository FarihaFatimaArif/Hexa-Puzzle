using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class IAPReward

{
    public int Amount;
    public Sprite Icon;
    public RewardType RewardType;
   
}

public enum RewardType { Coins, Skips, RemoveAds };
