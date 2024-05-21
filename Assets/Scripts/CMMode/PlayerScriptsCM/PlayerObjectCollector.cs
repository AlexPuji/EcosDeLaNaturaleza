using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjectCollector : MonoBehaviour
{
    public int objectCount = 0;
    public Text objectCountText;

    public void CollectObject()
    {
        objectCount++;
        UpdateObjectCountText();
    }

    public void AddObject(int count)
    {
        objectCount += count;
        UpdateObjectCountText();
    }

    private void UpdateObjectCountText()
    {
        objectCountText.text = "x " + objectCount.ToString();
    }
}
