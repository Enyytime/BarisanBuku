using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoh_Controller : MonoBehaviour
{
    public Machine m;
    public Contoh_Switch s1,s2;
    public GameObject submit;
    public void Submit()
    {
        if(s1.state && s2.state)
        {
            m.Solved();
        }
    }
}
