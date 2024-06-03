using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePanels : MonoBehaviour
{
    public static MachinePanels Instance {get; private set;}
    // public Dictionary<string, Machine> machines = new Dictionary<string, Machine>();
    public List<Machine> machines; 
    // public Dictionary<string, bool> machinesSolved = new Dictionary<string, bool>();
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
        
        // machinesSolved = new List<bool>(machines.Count);
        // for(int i=0; i<machines.Count; i++)
        // {
        //     machinesSolved.Add(false);
        // }
    }
    public void EnterMachine(string machineName)
    {
        // if(machinesSolved[machineID]) return;
        foreach(Machine machine in machines)
        {
            if(machine.machineName == machineName)
            {
                if(machine.AskIfSolved()==true) return;
                machine.Enter();
                return;
            }
        }
        // machines[machineID].Enter();
    }
    // public void SetSolved(int machineID)
    // {
    //     machinesSolved[machineID] = true;
    // }
    public void GenerateItemAfterSolved(List<int> itemIDs)
    {
        foreach(int itemID in itemIDs)
        {
            itemsController.GenerateNewItems(itemID);
        }
    }
}
