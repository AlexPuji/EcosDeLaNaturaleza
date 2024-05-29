using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private KeyCode moveUpKey;
    private KeyCode moveDownKey;
    private KeyCode moveLeftKey;
    private KeyCode moveRightKey;
    private KeyCode attackKey;
    private KeyCode interactKey;

    void Start()
    {
        // Cargar las teclas desde PlayerPrefs
        moveUpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveUp", "W"));
        moveDownKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveDown", "S"));
        moveLeftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeft", "A"));
        moveRightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRight", "D"));
        attackKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack", "Mouse0"));
        interactKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E"));
    }

    void Update()
    {
        // Movimiento
        if (Input.GetKey(moveUpKey))
        {
            // Código para mover hacia arriba
        }
        if (Input.GetKey(moveDownKey))
        {
            // Código para mover hacia abajo
        }
        if (Input.GetKey(moveLeftKey))
        {
            // Código para mover hacia la izquierda
        }
        if (Input.GetKey(moveRightKey))
        {
            // Código para mover hacia la derecha
        }

        // Ataque
        if (Input.GetKeyDown(attackKey))
        {
            // Código para atacar
        }

        // Interactuar
        if (Input.GetKeyDown(interactKey))
        {
            // Código para interactuar
        }
    }

    public void UpdateKeybinds()
    {
        moveUpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveUp", "W"));
        moveDownKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveDown", "S"));
        moveLeftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeft", "A"));
        moveRightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRight", "D"));
        attackKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack", "Mouse0"));
        interactKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E"));
    }
}
