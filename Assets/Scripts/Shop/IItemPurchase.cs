public interface IItemPurchase
{
    public void PurchaseSuccess(IAPItem iAPItem);
    void PurchaseFail(IAPItem iAPItem);
}