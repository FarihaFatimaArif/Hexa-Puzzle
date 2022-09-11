using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

[CreateAssetMenu(menuName = "ScriptableObject/IAP/IAPShop", order = 1, fileName = "IAPShop")]
public class IAPShop : ScriptableObject , IStoreListener
{
    [SerializeField] List<IAPItem> IAPItems;

    IStoreController _controller;
    IExtensionProvider _extensionProvider;

    public ProductCollection products => throw new NotImplementedException();

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _controller = controller;
        _extensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        throw new NotImplementedException();
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        
        throw new NotImplementedException();
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        //IItemPurchase.PurchaseSuccess();
        throw new NotImplementedException();
    }

    public void PurchaseIAP(string id)
    {
        _controller.InitiatePurchase(id);
    }
}
