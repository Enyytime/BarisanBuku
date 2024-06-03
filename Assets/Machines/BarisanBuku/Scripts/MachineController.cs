using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIButton = UnityEngine.UI.Button;

public class MachineController : MonoBehaviour
{
    [System.Serializable]
    public class ButtonPosition
    {
        public GameObject buttonObject;
        public Transform slot;
        public UIButton Button => buttonObject.GetComponent<UIButton>();
    }
    public Machine machine;

    [System.Serializable]
    public class ButtonAnswer
    {
        public string buttonName;
        public Transform correctSlot;
    }

    public ButtonPosition[] startingButtonPositions;
    public UIButton[] buttons;
    public ButtonAnswer[] buttonAnswers;
    public GridLayoutGroup grid;
    public UIButton checkButton;
    public UIButton resetButton;
    private Dictionary<Transform, string> slotToButtonNameMap;

    private UIButton selectedButton = null;
    private Transform selectedButtonParent = null;

    private void Awake()
    {
        SetStartingButtonPositions();
        CreateSlotToButtonNameMap();
        SetButtonAnswers();
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
        
        checkButton.onClick.AddListener(CheckAnswer);

        resetButton.onClick.AddListener(ResetButtons);
        Debug.Log("tes2");    
    }

    private void OnButtonClick(int buttonIndex)
    {
        if (selectedButton == null)
        {
            selectedButton = buttons[buttonIndex];
            selectedButtonParent = selectedButton.transform.parent;
            selectedButton.interactable = false;
        }
        else if (selectedButton != buttons[buttonIndex])
        {
            Transform buttonParent = buttons[buttonIndex].transform.parent;
            Vector3 buttonPosition = buttons[buttonIndex].transform.localPosition;

            selectedButton.transform.SetParent(buttonParent);
            selectedButton.transform.localPosition = buttonPosition;

            buttons[buttonIndex].transform.SetParent(selectedButtonParent);
            buttons[buttonIndex].transform.localPosition = Vector3.zero;

            selectedButton.interactable = true;
            selectedButton = null;

            LayoutRebuilder.MarkLayoutForRebuild(selectedButtonParent.GetComponent<RectTransform>());
            LayoutRebuilder.MarkLayoutForRebuild(buttonParent.GetComponent<RectTransform>());
        }
    }

    private void SetStartingButtonPositions()
    {
        foreach (ButtonPosition buttonPosition in startingButtonPositions)
        {
            buttonPosition.Button.transform.SetParent(buttonPosition.slot);
            buttonPosition.Button.transform.localPosition = Vector3.zero;
        }
    }

    private void CreateSlotToButtonNameMap()
    {
        slotToButtonNameMap = new Dictionary<Transform, string>();

        foreach (ButtonAnswer buttonAnswer in buttonAnswers)
        {
            if (!slotToButtonNameMap.ContainsKey(buttonAnswer.correctSlot))
            {
                slotToButtonNameMap.Add(buttonAnswer.correctSlot, buttonAnswer.buttonName);
            }
        }
    }

    private void SetButtonAnswers()
    {
        foreach (UIButton button in buttons)
        {
            button.onClick.AddListener(() => CheckButtonAnswer(button));
        }
    }

    private void CheckButtonAnswer(UIButton button)
    {
        string buttonName = button.name;
        foreach (KeyValuePair<Transform, string> pair in slotToButtonNameMap){
            Transform correctSlot = pair.Key;
            string correctButtonName = pair.Value;
            if (IsButtonNameMatch(buttonName, correctButtonName) && correctSlot.childCount == 0)
            {
                button.transform.SetParent(correctSlot, false);
                // Debug.Log("Winner!");
                return;
            }
        }
    }
    private bool IsButtonNameMatch(string buttonName, string correctButtonName)
    {
        // Compare button names ignoring case and ignoring spaces
        return buttonName.Equals(correctButtonName, System.StringComparison.OrdinalIgnoreCase)
            || buttonName.Replace(" ", "").Equals(correctButtonName.Replace(" ", ""), System.StringComparison.OrdinalIgnoreCase);
    }

    private void CheckAnswer()
    {
        List<string> orderedButtonNames = new List<string>();

        // Iterate over the buttonAnswers array to get the correct order of button names
        foreach (ButtonAnswer buttonAnswer in buttonAnswers)
        {
            orderedButtonNames.Add(buttonAnswer.buttonName);
        }

        // Check if the buttons are in the correct order
        for (int i = 0; i < orderedButtonNames.Count; i++)
        {
            Transform correctSlot = buttonAnswers[i].correctSlot;
            string correctButtonName = orderedButtonNames[i];

            if (correctSlot.childCount > 0)
            {
                UIButton button = correctSlot.GetChild(0).GetComponent<UIButton>();
                string buttonName = button.name;

                if (!IsButtonNameMatch(buttonName, correctButtonName))
                {
                    Debug.Log("Incorrect order!");
                    ResetButtons();
                    return;
                }
            }
            else
            {
                Debug.Log("Incomplete answer!");
                ResetButtons();
                return;
            }
        }

        // If all buttons are in the correct order, print "Winner!"
        Debug.Log("Winner!");
        machine.Solved();
    }

    private void ResetButtons()
    {
        // Reset each button to its starting position
        foreach (ButtonPosition buttonPosition in startingButtonPositions)
        {
            buttonPosition.Button.transform.SetParent(buttonPosition.slot);
            buttonPosition.Button.transform.localPosition = Vector3.zero;
            buttonPosition.Button.interactable = true;
        }
    
        // Clear the selected button
        selectedButton = null;
        selectedButtonParent = null;
    }

}