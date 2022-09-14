using UnityEngine;
using UnityEngine.Purchasing;
using System;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObject/IAP/IAPItem", order = 1, fileName = "IAPItem")]
public class IAPItem : ScriptableObject
{
    public string SKU;
    public string Title;
    public float Price = 0;
    public List<IAPReward> Rewards;
    public ProductType ProductType;
    [NonSerialized] public Product Product;

    ProductDefinition _productDefinition;
    public ProductDefinition ProductDefinition
    {
        get
        {
            if (_productDefinition == null)
            {
                _productDefinition = new ProductDefinition(SKU, ProductType);
            }
            return _productDefinition;
        }
    }
}
