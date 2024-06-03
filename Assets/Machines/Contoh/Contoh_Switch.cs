using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoh_Switch : MonoBehaviour
{
    public bool state;
    void Start()
    {
        state = false;
    }
    public void SwitchState()
    {
        state = !state;
    }
}
