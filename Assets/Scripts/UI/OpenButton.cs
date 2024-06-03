using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    [SerializeField] GameObject targetGameObject;
    // Start is called before the first frame update
    public void ActivatePanel()
    {
        GameManager.Instance.audioManager.GetComponent<AudioManager>().clickSoundPlay();
        if (!targetGameObject.activeInHierarchy)
            targetGameObject.SetActive(true);
    }
}