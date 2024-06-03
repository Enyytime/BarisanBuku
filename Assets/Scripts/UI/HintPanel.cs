using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintPanel : MonoBehaviour
{
    public static HintPanel instance;

    public GameObject hintPanel;
    public GameObject itemHint;
    public GameObject confirmationText;
    public GameObject selectItem;
    public GameObject buyButton;
    public TextMeshProUGUI itemHintText;

    public bool check = false;

    void Awake() { instance = this;  }

    ActivePanel previousPanel;

    public void OnEnable()
    {
        previousPanel = GameManager.Instance.activePanel;
        GameManager.Instance.activePanel = ActivePanel.hint;
        hintPanel.SetActive(true);
        selectItem.SetActive(true);
        buyButton.SetActive(false);
        itemHint.SetActive(false);
        confirmationText.SetActive(false);
        check=true;
    }

    public void transition()
    {
        buyButton.SetActive(true);
        confirmationText.SetActive(true);
        selectItem.SetActive(false);
    }

    public void OnDisable()
    {
        GetSetItemHintText("");
        GameManager.Instance.activePanel = previousPanel;
        GameManager.Instance.selectedItemHint = null;
        selectItem.SetActive(true);
        confirmationText.SetActive(false);
        itemHint.SetActive(false);
        hintPanel.SetActive(false);
        buyButton.SetActive(false);
        check = false;
    }

    public void BuyButton()
    {
        GameManager.Instance.audioManager.GetComponent<AudioManager>().clickSoundPlay();
        if(GameManager.Instance.player.UseCoin(5))
        {
            confirmationText.SetActive(false);
            selectItem.SetActive(false);
            itemHint.SetActive(true);
            buyButton.SetActive(false);
            ShowHint();
        }
        else
        {
            GetSetItemHintText("Neleci Coin Tidak Cukup");
        }
    }

    public void ShowHint()
    {
        string hint = GameManager.Instance.selectedItemHint.ObjectDescription; // Adjust this according to your implementation
        GetSetItemHintText(hint);
        buyButton.SetActive(false);
    }

    public void GetSetItemHintText(string text)
    {
        itemHintText.text = text;
    }
}
