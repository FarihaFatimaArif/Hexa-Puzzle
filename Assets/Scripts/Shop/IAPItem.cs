using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/IAP/IAPItem", order = 1, fileName = "IAPItem")]
public class IAPItem : ScriptableObject
{
    public string SKU;
    public string Title;
    public float Price = 0;
    public List<IAPReward> Rewards;

}
