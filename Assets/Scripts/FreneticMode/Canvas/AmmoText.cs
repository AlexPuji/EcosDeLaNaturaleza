using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public Text ammoText;
    public int maxAmmo = 40; 
    public int currentAmmo; 

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo.ToString();
        }
    }

    
    public void DecreaseAmmo()
    {
        currentAmmo--;

        if (currentAmmo < 0)
        {
            currentAmmo = 0;
        }

        UpdateAmmoUI();
    }
}
