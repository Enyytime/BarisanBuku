    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    // COPY ISI CLASS
    // public int machineID;
    public string machineName;
    private bool isSolved = false;
    // public ItemPage itemPage;
    public List<int> itemIDsToGenerate; 
    private MachinePanels machinePanels;

    void Awake(){
        machinePanels = FindObjectOfType<MachinePanels>();
    }

    void Start()
    {
        if(isSolved)
        {
            Exit();
            return;
        }
    }
    public bool AskIfSolved()
    {
        return isSolved;
    }
    public void Solved()
    {
        isSolved = true;
        // nanti ini taro utk generate objectnya
        // ItemPage.CreateItem(generate_itemSO);
        // SISTEM POIN
        // MachinePanels.Instance.SetSolved(machineName);
        MachinePanels.Instance.GenerateItemAfterSolved(itemIDsToGenerate);
        Exit();
    }
    public void Enter()
    {
        gameObject.SetActive(true);
        machinePanels.buttonPov.SetActive(false);
    }
    public void Exit()
    {
        gameObject.SetActive(false);
        machinePanels.buttonPov.SetActive(true);
    }

    /*
    GUIDE UTK MACHINE
    drag prefab "NamaMachine" dari Assets\Prefabs\Machine
    jadikan sebagai child dari GO "MachinePanels" di hierarchy
    dan rename "NamaMachine" sesuai nama machine kalian

    prefab "NamaMachine" yg udah direname tadi, melalui Inspector:
    - isi "Machine Name" dengan nama machine kalian (GUNAKAN PascalCase)
    - isi "Item I Ds To Generate" dengan yg akan kegenerate ketika machine ke solved

    untuk ItemSO yg trigger machine kalian:
    - set ObjectType ke Machine
    - isi "Machine Name" dengan nama machine kalian (GUNAKAN PascalCase)

    untuk ItemSO hasil generate:
    - "Generate In Inventory" set ke true

    di GO "MachinePanels", ke Inspector, di variabel Machines,
    tambah ukuran Listnya dan assign (drag machine kalian) sbg element baru dari List

    silakan buat GO, background, asset, lain2 sesuai kebutuhan machine kalian sebagai
    child of prefab tadi, ketika machinenya sudah ke solve, panggil function
    "Solved" yang ada pada prefab machine kalian (yg ada Machine.cs nya)

    segala scripts, assets, prefab yg kalian buat utk machine kalian
    bisa disave di Assets\Machines\"NamaMachineKalian"

    KALO MAU NGETEST:
    - prefab machine kalian melalui inspector, set activenya di set ke FALSE

    have fun
    */
}
