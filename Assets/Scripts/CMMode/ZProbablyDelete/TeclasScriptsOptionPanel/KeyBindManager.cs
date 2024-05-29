using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    public TMP_Text moveUpText;
    public TMP_Text moveDownText;
    public TMP_Text moveLeftText;
    public TMP_Text moveRightText;
    public TMP_Text attackText;
    public TMP_Text interactText;

    private Dictionary<string, KeyCode> keybinds = new Dictionary<string, KeyCode>();
    private GameObject currentKey;
    private PlayerInputHandler playerInputHandler;

    void Start()
    {
        playerInputHandler = FindObjectOfType<PlayerInputHandler>();

        keybinds.Add("MoveUp", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveUp", "W")));
        keybinds.Add("MoveDown", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveDown", "S")));
        keybinds.Add("MoveLeft", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeft", "A")));
        keybinds.Add("MoveRight", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRight", "D")));
        keybinds.Add("Attack", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack", "Mouse0")));
        keybinds.Add("Interact", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E")));

        UpdateKeyText();
    }

    void UpdateKeyText()
    {
        moveUpText.text = "Mover Arriba: " + keybinds["MoveUp"];
        moveDownText.text = "Mover Abajo: " + keybinds["MoveDown"];
        moveLeftText.text = "Mover Izquierda: " + keybinds["MoveLeft"];
        moveRightText.text = "Mover Derecha: " + keybinds["MoveRight"];
        attackText.text = "Atacar: " + keybinds["Attack"];
        interactText.text = "Interactuar: " + keybinds["Interact"];
    }

    public void ChangeKey(GameObject clickedKey)
    {
        currentKey = clickedKey;
        currentKey.GetComponentInChildren<TMP_Text>().text = "Press a key";
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keybinds[currentKey.name] = e.keyCode;
                currentKey.GetComponentInChildren<TMP_Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void SaveKeys()
    {
        foreach (var key in keybinds)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();

        // Asegurarse de que PlayerInputHandler actualice sus teclas
        if (playerInputHandler != null)
        {
            playerInputHandler.UpdateKeybinds();
        }
    }
}
