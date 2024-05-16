using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectModeButton : MonoBehaviour
{
    public void ReturnToSelectMode()
    {
        SceneManager.LoadScene("SelectMode");
    }
}
