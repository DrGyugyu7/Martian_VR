using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotTemplate;
    private Transform slotContainer;
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }
    private void RefreshInventoryItems()
    {
        foreach (Item item in inventory.GetItemList())
        {
            Instantiate(itemSlotTemplate, slotContainer);
        }
    }
}
