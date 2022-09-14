using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObject/RewardGrantedSO", order = 1, fileName = "RewardGranted")]
public class RewardGranted : ScriptableObject
{
    public bool RemoveAds=false;
    public int NoOfCoins;
    public int NoOfSkips;
}