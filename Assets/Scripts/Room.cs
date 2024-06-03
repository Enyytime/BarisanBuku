using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public Image image;
    public ActiveRoom activeRoom;
    public RoomSide roomSide;
    public Sprite[] backgroundSprites;
    public EnumFunction enumFunction;
    public static Room instance;
    public ActiveRoom curActiveRoom;
    public RoomSide curRoomSide;
    public GameObject backButton;
    public GameObject leftRightArrow;

    private void Start()
    {
        LoadBackgroundSprites();
        instance = this;
        curActiveRoom = activeRoom;
        curRoomSide = roomSide;
    }

    private void LoadBackgroundSprites()
    {
        backgroundSprites = Resources.LoadAll<Sprite>(activeRoom.ToString());

        if (backgroundSprites.Length > 0){
            image.sprite = backgroundSprites[0];
        } else {
            Debug.Log("no sprites at resources/{room}");
        }

    }

public void ChangeBackgroundPOVObject(Sprite povSprite, ItemSO itemSO)
    {
        curActiveRoom = activeRoom;
        curRoomSide = roomSide;
        activeRoom = itemSO.ObjectPOVActiveRoom;
        roomSide = itemSO.ObjectPOVRoomSide;
        Debug.Log(activeRoom + " - " + roomSide + " - " + povSprite.name);
        image.sprite = povSprite;
        if(activeRoom.ToString().Contains("Pov")){
            backButton.SetActive(true);
            leftRightArrow.SetActive(false);
        }
    }
    
}
