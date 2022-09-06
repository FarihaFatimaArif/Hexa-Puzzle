using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class SwitchPage : MonoBehaviour
{
    [SerializeField] HorizontalScrollSnap ScrollSnap;
    //[SerializeField] int PageNumber;
   public void SwitchingPage(int pageNumber)
    {
        ScrollSnap.GoToScreen(pageNumber);
    }
}