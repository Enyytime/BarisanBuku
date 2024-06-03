using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    public ItemPage itemPage;
    public Dictionary<ActiveRoom, Dictionary<RoomSide, List<ItemSO>>> itemsDict = new Dictionary<ActiveRoom, Dictionary<RoomSide, List<ItemSO>>>();
    public Dictionary<ActiveRoom, Dictionary<RoomSide, List<ItemSO>>> currItemDict = new Dictionary<ActiveRoom, Dictionary<RoomSide, List<ItemSO>>>();
    private Room room;
    public static ItemsController instance;

    void Start(){
        instance = this;
        room = GameObject.Find("Room").GetComponent<Room>();
        InitEachItems();
        SpawnItems();
    }

    void Update(){

    }

    private void InitEachItems(){
        foreach (ItemSO item in GameManager.Instance.allItemsList){
            Debug.Log("Item: " + item.ObjectName + " - " + item.ActiveRoom + " - " + item.RoomSide);
            if (!itemsDict.ContainsKey(item.ActiveRoom)){
                itemsDict.Add(item.ActiveRoom, new Dictionary<RoomSide, List<ItemSO>>());
                Debug.Log("Add ActiveRoom: " + item.ActiveRoom);
            }

            if (!itemsDict[item.ActiveRoom].ContainsKey(item.RoomSide)){
                itemsDict[item.ActiveRoom].Add(item.RoomSide, new List<ItemSO>());
                Debug.Log("Add RoomSide: " + item.RoomSide);
            }

            itemsDict[item.ActiveRoom][item.RoomSide].Add(item);
        }

        Debug.Log("ItemsDict: " + itemsDict.Count + " - " + itemsDict[room.activeRoom].Count + " - " + itemsDict[room.activeRoom][room.roomSide].Count);
    }

    // --- UNTUK SPAWAN INITIAL OBJECT
    public void SpawnItems(){
        // --- COBA LANGSUNG DI SPAWN DI AWAL, NANTI TINGGAL MENYESUAIKAN KONDISI ---
        // foreach (ItemSO item in GameManager.Instance.allItemsList){
        //     if (item.IsInitialObject){
        //         itemPage.CreateItem(item);
        //     }
        // }
        
        if (!currItemDict.ContainsKey(room.activeRoom)){
            currItemDict.Add(room.activeRoom, new Dictionary<RoomSide, List<ItemSO>>());
        }

        if (!currItemDict[room.activeRoom].ContainsKey(room.roomSide)){
            currItemDict[room.activeRoom].Add(room.roomSide, new List<ItemSO>());

            foreach (ItemSO item in itemsDict[room.activeRoom][room.roomSide]){
                if (item.IsInitialObject){
                    currItemDict[room.activeRoom][room.roomSide].Add(item);
                    itemPage.CreateItem(item);
                }
            }
        }
        else {
            // --- SPAWN INITIAL OBJECT SESUAI DENGAN ROOM DAN POV SAAT INI (SEBAGAI CONTOH ROOM1 POV AFORNT)
            foreach (ItemSO item in currItemDict[room.activeRoom][room.roomSide]){
                itemPage.CreateItem(item);
            }
        }
    }

    public void DestroyAllObjects(){
        itemPage.DestroyAllItems();
    }

    public void DestoryCombinedItems(GameObject obj1, GameObject obj2, ItemSO item1, ItemSO item2){
        foreach (ItemSO item in itemsDict[room.activeRoom][room.roomSide]){
            Debug.Log("Item: " + item.ObjectName + " - " + item.ObjectID + "type: " + item.ObjectType);
        }
        // --- NANTINYA DIBUAT SESUAI DENGAN ITEM YANG SUDAH DI COMBINE
        currItemDict[room.activeRoom][room.roomSide].Remove(item1);
        currItemDict[room.activeRoom][room.roomSide].Remove(item2);
        itemsDict[room.activeRoom][room.roomSide].Remove(item1);
        itemsDict[room.activeRoom][room.roomSide].Remove(item2);
        itemPage.RemoveItem(obj1);
        itemPage.RemoveItem(obj2);
    }

    public void CombineItems(GameObject dragItem, GameObject targetItem){
        Items item1 = dragItem.GetComponent<Items>();
        Items item2 = targetItem.GetComponent<Items>();
        if (item1.itemSO.CombineWithObjectID == item2.itemSO.ObjectID && item2.itemSO.CombineWithObjectID == item1.itemSO.ObjectID){
            Debug.Log("Combine Success");
            DestoryCombinedItems(dragItem, targetItem, item1.itemSO, item2.itemSO);
            GenerateNewItems(item1.itemSO.GeneratesObejctID);
        }
    }

    public void GenerateNewItems(int itemID){
        ItemSO newItem = FindItemsByID(itemID);
        if (newItem != null){
            // --- ADD CURRENT ITEM TO CURRITEMDICT, TAPI NANTI AJA BLUM KU IMPLEMENTASIIN
            currItemDict[room.activeRoom][room.roomSide].Add(newItem);
            itemPage.CreateItem(newItem);
        } else {
            Debug.Log("Item not found");
        }
    }

    private ItemSO FindItemsByID(int itemID){
        // --- NANTINYA DICTNYA BAKAL DIGANTI SESUAI DENGAN ROOM DAN POV SAAT INI SUPAYA LOOPING YANG DILAKUKAN HANYA PADA ITEM YANG ADA DI ROOM DAN POV SAAT INI
        // --- BISA AJA FOREACH IN ALLITEMS, TAPI KALO ITEMNYA BANYAK, BAKAL LAMA
        foreach (ItemSO item in itemsDict[room.activeRoom][room.roomSide]){
            if (item.ObjectID == itemID){
                return item;
            }
        }
        return null;
    }

    // public void UpdateItems(ActiveRoom activeRoom, RoomSide RoomSide){
    //     if (currItemDict.ContainsKey(activeRoom)){
    //         if (currItemDict[activeRoom].ContainsKey(RoomSide)){
    //             foreach (ItemSO item in currItemDict[activeRoom][RoomSide]){
    //                 itemPage.CreateItem(item);
    //             }
    //         }
    //     }
    // }
}
