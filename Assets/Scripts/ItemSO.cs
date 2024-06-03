using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [Header("Object Data")]
    [field: SerializeField]
    public int ObjectID;
    [field: SerializeField]
    public string ObjectName;
    [field: SerializeField]
    [TextArea]
    public string ObjectDescription;
    [field: SerializeField]
    public Sprite ObjectImage;


    [Header("Object Specification")]
    [field: SerializeField]
    public ObjectTypes ObjectType;
    [field: SerializeField]
    public string machineName;
    public int unlockID;
    public bool IsInitialObject;

    [Header("Object POV")]
    [field: SerializeField]
    public Sprite ObjectPOVImage;
    [field: SerializeField]
    public ActiveRoom ObjectPOVActiveRoom;
    [field: SerializeField]
    public RoomSide ObjectPOVRoomSide;    


    [Header("Object Combination")]
    [field: SerializeField]
    public int CombineWithObjectID;
    [field: SerializeField]
    public int GeneratesObejctID;
    

    [Header("Object Placement")]
    [field: SerializeField]
    public ActiveRoom ActiveRoom;
    [field: SerializeField]
    public RoomSide RoomSide;
    public bool generateInInventory;


    [Header("Object Position")]
    [field: SerializeField]
    public Vector3 ObjectPosition;
    [field: SerializeField]
    public float ObjectWidth;
    [field: SerializeField]
    public float ObjectHeight;

}
