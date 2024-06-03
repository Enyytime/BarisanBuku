using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsPanel : MonoBehaviour
{
    public static OptionsPanel instance;

    public GameObject optionsPanel;

    void Awake() { instance = this;  }

    ActivePanel previousPanel;

    public void OnEnable()
    {
        previousPanel = GameManager.Instance.activePanel;
        GameManager.Instance.activePanel = ActivePanel.options;
        optionsPanel.SetActive(true);
    }

    public void OnDisable()
    {
        GameManager.Instance.activePanel = previousPanel;
        optionsPanel.SetActive(false);
    }
}