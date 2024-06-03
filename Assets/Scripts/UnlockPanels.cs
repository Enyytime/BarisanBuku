using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPanels : MonoBehaviour
{
    public static UnlockPanels Instance {get; private set;}
    public List<Unlock> unlocks; 
    private List<bool> unlocksSolved;
    public ItemsController itemsController;
    public GameObject buttonPov;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        unlocksSolved = new List<bool>(unlocks.Count);
        for(int i=0; i<unlocks.Count; i++)
        {
            unlocksSolved.Add(false);
        }
    }
    public void EnterUnlock(int unlockID)
    {
        if(unlocksSolved[unlockID]) return;
        unlocks[unlockID].Enter();
    }
    public void SetSolved(int unlockID)
    {
        unlocksSolved[unlockID] = true;
    }
    public void GenerateItemAfterSolved(List<int> unlockIDs)
    {
        foreach(int itemID in unlockIDs)
        {
            itemsController.GenerateNewItems(itemID);
        }
    }
}
