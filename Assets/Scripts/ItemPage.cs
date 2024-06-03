using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPage : MonoBehaviour
{
    public Items itemPrefab;
    public RectTransform itemContainer;

    public void CreateItem(ItemSO itemSO){
        Items newItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        newItem.transform.SetParent(itemContainer);
        newItem.InitialiazeItem(itemSO);
        if(itemSO.generateInInventory)
        {
            InventoryManager.instance.AddItem(newItem);
        }
    }

    public void DestroyAllItems(){
        foreach (Transform child in itemContainer){
            Destroy(child.gameObject);
        }
    }

    public void RemoveItem(GameObject item){
        Destroy(item);
    }
}
