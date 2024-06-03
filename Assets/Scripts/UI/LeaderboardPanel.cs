using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardPanel : MonoBehaviour
{
    public static LeaderboardPanel instance;

    public GameObject leaderboardPanel;

    void Awake() { instance = this;  }
    
    ActivePanel previousPanel;
    
    public void OnEnable()
    {
        previousPanel = GameManager.Instance.activePanel;
        GameManager.Instance.activePanel = ActivePanel.leaderboard;
        leaderboardPanel.SetActive(true);
    }

    public void OnDisable()
    {
        leaderboardPanel.SetActive(false);
        GameManager.Instance.activePanel = previousPanel;
    }
}