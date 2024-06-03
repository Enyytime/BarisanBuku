using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumFunction : MonoBehaviour
{
    public ActiveRoom ChangeRoom(int idx){
        switch (idx){
            case 0 : return ActiveRoom.Chillroom;
            default:
                return ActiveRoom.Chillroom;
        }

    }

    public RoomSide ChangeSide(int idx){
        switch (idx){
            case 0 : return RoomSide.AFront;
            case 1 : return RoomSide.BRight;
            case 2 : return RoomSide.CBack;
            case 3 : return RoomSide.DLeft;
            default:
                return RoomSide.AFront;
        }
        
    }
}
