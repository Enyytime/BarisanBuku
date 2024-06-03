using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    public GameObject audioManager;
    public List<ItemSO> allItemsList;
    public Player player;
    [HideInInspector] public ItemSO selectedItemHint;

    public void Start()
    {
        player.Init();
    }
    
    // Keeps track which panel open
    public ActivePanel activePanel = ActivePanel.none;

    // Each Panel reference
    #region Header Panel References
    [Space(10)]
    [Header("Panel References")]
    #endregion
    public GameObject hintPanel;
    public GameObject leaderboardPanel;
    public GameObject optionsPanel;
    public GameObject unlockPanel;

    // void Start()
    // {
    //     player.Init();
    // }
}