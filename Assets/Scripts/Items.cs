using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Items : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    public Image itemImage;
    public ItemSO itemSO;
    public RectTransform itemTransform;
    private ItemsController itemsController;
    Transform originalParent;
    Vector3 startPosition;
    public static Items instance;
    // Machine machinePanel;
    int machineID;
    void Start(){
        instance = this;
        itemsController = FindObjectOfType<ItemsController>();
    }

    void Update(){
        
    }
    public void InitialiazeItem(ItemSO newItem)
    {
        itemSO = newItem;
        itemImage.sprite = itemSO.ObjectImage;
        itemTransform.anchoredPosition = new Vector3(itemSO.ObjectPosition.x, itemSO.ObjectPosition.y, itemSO.ObjectPosition.z);
        itemTransform.sizeDelta = new Vector2(itemSO.ObjectWidth, itemSO.ObjectHeight);
    }

    public void OnBeginDrag(PointerEventData eventData){
        if(itemSO.ObjectType == ObjectTypes.Pickable)
        {
            Debug.Log("OnBeginDrag");
            originalParent = transform.parent;
            startPosition = transform.position;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            itemImage.raycastTarget = false;

            // if(transform.parent.GetComponent<InventorySlot>()==null) return;
            // Vector2 slotSize = new Vector2(1f, 1f);
            // Vector2 currentSize = itemTransform.rect.size;
            // float widthScale = slotSize.x / currentSize.x;
            // float heightScale = slotSize.y / currentSize.y;
            // float scale = Mathf.Min(widthScale, heightScale);
            // Vector3 newScale = new Vector3(scale, scale, itemTransform.localScale.z);
            // itemTransform.localScale = newScale;
        }
    }

    public void OnDrag(PointerEventData eventData){
        if(itemSO.ObjectType == ObjectTypes.Pickable){
            transform.position = Input.mousePosition;
        }
    }

    public void OnDrop(PointerEventData eventData){
        if(itemSO.ObjectType == ObjectTypes.Combine){
            Items dragItem = eventData.pointerDrag.GetComponent<Items>();
            if (dragItem != null){
                Debug.Log("OnDrop" + dragItem.itemSO.ObjectName);
                Items targetItem = eventData.pointerEnter.GetComponent<Items>();
                if (targetItem != null){
                    Debug.Log("TargetDrop" + targetItem.itemSO.ObjectName);
                    // --- KARENA YANG DIDESTROY ITU GAMEOBJECTNYA
                    itemsController.CombineItems(dragItem.gameObject, targetItem.gameObject);
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData){
        if(itemSO.ObjectType == ObjectTypes.Pickable){
            Debug.Log("OnEndDrag");
            if(transform.parent.GetComponent<InventorySlot>()==null)
            {
                transform.SetParent(originalParent);
                transform.position = startPosition;
            }
            itemImage.raycastTarget = true;
        }
    }

    public void OnPointerClick(PointerEventData ped)
    {
        Debug.Log("clicked");
        Items dragItem = ped.pointerDrag.GetComponent<Items>();
        ObjectTypes tipe = dragItem.itemSO.ObjectType;
        if(dragItem.transform.parent.GetComponent<InventorySlot>()!=null)
        {
            // ada di inventory
            // interaksi di inventory
            Debug.Log("interaksi");
             // Mendapatkan data ItemSO dari Item yang diklik di inventory
            ItemSO clickedItemSO = dragItem.itemSO;
            GameManager.Instance.selectedItemHint = clickedItemSO;

            if (HintPanel.instance != null && HintPanel.instance.check == true)
            {
                HintPanel.instance.transition();
            }
                        
            return;
        }
        else if(tipe == ObjectTypes.Pickable)
        {
            InventoryManager.instance.AddItem(dragItem);
            ItemsController.instance.itemsDict[Room.instance.activeRoom][Room.instance.roomSide].Remove(dragItem.itemSO);
            ItemsController.instance.currItemDict[Room.instance.activeRoom][Room.instance.roomSide].Remove(dragItem.itemSO);
        }
        else if (tipe == ObjectTypes.Machine)
        {
            MachinePanels.Instance.EnterMachine(dragItem.itemSO.machineName);
        }
        else if (tipe == ObjectTypes.Povable)
        {
            Debug.Log("Povable");
            ItemsController.instance.DestroyAllObjects();
            Room.instance.ChangeBackgroundPOVObject(itemSO.ObjectPOVImage, itemSO);
            ItemsController.instance.SpawnItems();

        }
        else if (tipe == ObjectTypes.Unlock)
        {
            UnlockPanels.Instance.EnterUnlock(dragItem.itemSO.unlockID);
        }
        
    }
}

// NOTE, HATI - HATI DENGAN PENGGUNAAN INSTANCE, JANGAN SAMPAI SALAH, AKU PERNAH ERROR YANG MEMUNCULKAN BUG GRGR INSTANCE