using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindButton : MonoBehaviour
{
    public KeybindManager keybindManager;
    public string keyName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        keybindManager.ChangeKey(gameObject);
    }
}
