using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public Unlock u;
    public TMP_InputField inputText;
    
    public void Submit()
    {
        if(inputText.text == "BENAR" && inputText.text != "0" && inputText.text != "")
        {
            u.Solved();
        }
        else
        {
            Debug.Log("SALAH");
        }
    }
}
