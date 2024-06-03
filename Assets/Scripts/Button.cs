using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private Room room;
    private int curSpriteIndex = 0;
    private ItemsController itemsController;

    void Start(){
        itemsController = FindObjectOfType<ItemsController>();
    }

    public void RightArrow()
    {
        room.activeRoom = room.curActiveRoom;
        curSpriteIndex = (curSpriteIndex + 1) % room.backgroundSprites.Length;
        room.image.sprite = room.backgroundSprites[curSpriteIndex];
        room.roomSide = room.enumFunction.ChangeSide(curSpriteIndex);
        itemsController.DestroyAllObjects();
        itemsController.SpawnItems();
        Debug.Log("Right Arrow Clicked");
        room.backButton.SetActive(false);
    }

    public void LeftArrow()
    {
        room.activeRoom = room.curActiveRoom;
        curSpriteIndex = (curSpriteIndex - 1 + room.backgroundSprites.Length) % room.backgroundSprites.Length;
        room.image.sprite = room.backgroundSprites[curSpriteIndex];
        room.roomSide = room.enumFunction.ChangeSide(curSpriteIndex);
        itemsController.DestroyAllObjects();
        itemsController.SpawnItems();
        Debug.Log("Left Arrow Clicked");
        room.backButton.SetActive(false);
    }

    public void Back(){
        room.activeRoom = room.curActiveRoom;
        room.roomSide = room.curRoomSide;
        room.image.sprite = room.backgroundSprites[curSpriteIndex];
        itemsController.DestroyAllObjects();
        itemsController.SpawnItems();
        room.backButton.SetActive(false);
        room.leftRightArrow.SetActive(true);
    }
    
}
