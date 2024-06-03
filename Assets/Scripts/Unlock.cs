using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    // COPY ISI CLASS
    public int unlockID;
    private bool isSolved = false;
    public ItemPage itemPage;
    public List<int> itemIDsToGenerate; 
    private UnlockPanels unlockPanels;

    void Awake(){
        unlockPanels = FindObjectOfType<UnlockPanels>();
    }

    void Start()
    {
        if(isSolved)
        {
            Exit();
            return;
        }
    }
    public void Solved()
    {
        isSolved = true;
        // nanti ini taro utk generate objectnya
        // ItemPage.CreateItem(generate_itemSO);
        // SISTEM POIN
        UnlockPanels.Instance.SetSolved(unlockID);
        UnlockPanels.Instance.GenerateItemAfterSolved(itemIDsToGenerate);
        Exit();
    }
    public void Enter()
    {
        gameObject.SetActive(true);
        unlockPanels.buttonPov.SetActive(false);
    }
    public void Exit()
    {
        gameObject.SetActive(false);
        unlockPanels.buttonPov.SetActive(true);
    }
    // BUAT SCRIPT BARU SEBAGAI CONTROLLER UNLOCK KALIAN
    // COPY BAWAH INI
    // public NamaUnlockKalian u;
    // DRAG NamaUnlock game object ke u;
    // KALO SOLVED PANGGIL "u.SOLVED" dari script controller kalian
}
