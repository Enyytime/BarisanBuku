using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public InventorySlot pref_InventorySlot;
    private int showSize = 7;
    
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        foreach(Transform child in gameObject.transform)
        {
            if(child.GetComponent<InventorySlot>() != null)
            {
                slots.Add(child.GetComponent<InventorySlot>());
            }
        }
        // ExpandInventory(showSize);
        // ExpandInventory(showSize);
        Zero();
        // Debug.Log(transform.localPosition.x);
    }

    // public void OnDrop(PointerEventData ped)
    // {
    //     Debug.Log("im ondrop");
    //     Items item = ped.pointerDrag.GetComponent<Items>();
    //     AddItem(item);
    // }

    public void AddItem(Items item)
    {
        for(int i=0; i<slots.Count; i++)
        {
            if(slots[i].transform.childCount == 0)
            {
                Add(item, slots[i]);
                return;
            }
        }
        Debug.Log("INV full, expanding");
        int targetIndex = slots.Count;
        ExpandInventory(showSize);
        if(slots[targetIndex].transform.childCount == 0)
        {
            Add(item, slots[targetIndex]);
        }
    }
    private void Add(Items item, InventorySlot slot)
    {
        item.transform.SetParent(slot.GetComponent<RectTransform>());
        item.transform.position = slot.transform.position;
        ScaleToFitSlot(item.GetComponent<RectTransform>());
        // item.transform.localPosition = new Vector3(0,0,0);
        Debug.Log("INV masuk "+item.itemSO.ObjectID+" "+item.itemSO.ObjectName);
    }
    private void ScaleToFitSlot(RectTransform itemRT)
    {
        // Debug.Log("scaling");
        Vector2 slotSize = new Vector2(100f, 100f);
        Vector2 currentSize = itemRT.rect.size;
        float widthScale = slotSize.x / currentSize.x;
        float heightScale = slotSize.y / currentSize.y;
        float scale = Mathf.Min(widthScale, heightScale);
        Vector3 newScale = new Vector3(scale, scale, itemRT.localScale.z);
        itemRT.localScale = newScale;
    }

    public void ExpandInventory(int size)
    {
        for(int i=0; i<size; i++)
        {
            InventorySlot slot = Instantiate(pref_InventorySlot);
            // slot.transform
            slot.transform.SetParent(GetComponent<RectTransform>());
            slots.Add(slot);
            // !show ? slot.gameObject.SetActive(false);
        }
    }
    private void Dense()
    {
        int deleted = 0;
        for(int i=0; i<slots.Count; i++)
        {
            if(slots[i].transform.childCount == 0)
            {
                Destroy(slots[i]);
                i--;
                deleted++;
            }
        }
        int target = slots.Count;
        int filled = slots.Count;
        while(target%showSize != 0) target++;
        // ExpandInventory(target-filled, true);
        ExpandInventory(target-filled);
        Vector3 zeroV = new Vector3(0,transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = zeroV;
    }

    private int slotSize = 100;
    public void Zero()
    {
        Vector3 cur = transform.position;
        cur.x = +610;
        transform.position = cur;
        left.SetActive(false);
        right.SetActive(slots.Count>7 ? true : false);
    }
    public GameObject left,right;
    public void Carousel(bool toRight)
    {
        // Debug.Log("BEF "+transform.localPosition.x);
        Vector3 cur = transform.localPosition;
        if(toRight) cur.x -= 700;
        else cur.x += 700;
        transform.localPosition = cur;
        // Debug.Log("AFT "+transform.localPosition.x);

        int mins = -350;
        int maxs = -((slots.Count-7)*slotSize)-350;
        int cx = (int)cur.x;
        // Debug.Log(cx+" "+mins+" "+maxs);
        left.SetActive(cx==mins ? false : true);
        right.SetActive(cx==maxs ? false : true);
    }
}

