using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxLife(float life)
    {
        slider.maxValue = life;
        slider.value = life;
    }

    public void SetLife(float life)
    {
        slider.value = life;
    }
}
