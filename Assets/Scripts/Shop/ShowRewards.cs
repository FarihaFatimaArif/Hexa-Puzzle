using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShowRewards : MonoBehaviour
{
    [SerializeField] RewardGranted RewardGranted;
    [SerializeField] TextMeshProUGUI CoinsText;
    [SerializeField] TextMeshProUGUI SkipsText;
    private void Start()
    {
        UpdateRewards();
    }
    public void UpdateRewards()
    {
        CoinsText.text = RewardGranted.NoOfCoins.ToString();
        SkipsText.text = RewardGranted.NoOfSkips.ToString();
    }

}
