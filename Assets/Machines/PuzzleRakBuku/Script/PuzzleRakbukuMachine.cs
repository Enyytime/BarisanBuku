using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIButton = UnityEngine.UI.Button;

public class PuzzleRakBukuMachine : MonoBehaviour
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
    private List<string> clickedButtonNames = new List<string>();

    public string correctAnswer = "24"; // The correct two-digit answer

    private void Awake()
    {
        SetStartingButtonPositions();
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
        
        checkButton.onClick.AddListener(CheckAnswer);
        resetButton.onClick.AddListener(ResetButtons);
    }

    private void OnButtonClick(int buttonIndex)
    {
        if (clickedButtonNames.Count < 2)
        {
            UIButton button = buttons[buttonIndex];
            clickedButtonNames.Add(button.name);
            button.interactable = false; // Optional: disable the button after clicking
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

    private void CheckAnswer()
    {
        // Check if two buttons were clicked
        if (clickedButtonNames.Count != 2)
        {
            Debug.Log("You need to click exactly two buttons!");
            ResetButtons();
            return;
        }

        // Concatenate the names of the two clicked buttons
        string concatenatedResult = clickedButtonNames[0] + clickedButtonNames[1];

        // Check if the concatenated result matches the correct answer
        if (concatenatedResult == correctAnswer)
        {
            Debug.Log("Winner!");
            machine.Solved();
        }
        else
        {
            Debug.Log("Incorrect answer!");
            ResetButtons();
        }
    }

    private void ResetButtons()
    {
        // Reset each button to its starting position
        foreach (ButtonPosition buttonPosition in startingButtonPositions)
        {
            buttonPosition.Button.transform.SetParent(buttonPosition.slot);
            buttonPosition.Button.transform.localPosition = Vector3.zero;
            buttonPosition.Button.interactable = true; // Re-enable the button
        }

        // Clear the list of clicked button names
        clickedButtonNames.Clear();
    }
}
