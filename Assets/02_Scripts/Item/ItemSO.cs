using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public Item.ItemType itemType;
    public string itemName;
    public Sprite itemSprite;
}
