using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData ped)
    {
        Debug.Log("is ondrop");
        Items item = ped.pointerDrag.GetComponent<Items>();
        InventoryManager.instance.AddItem(item);
    }
}
