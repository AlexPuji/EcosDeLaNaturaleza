using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootCollector : MonoBehaviour
{
    public int bootsCollected = 0; 
    public int bootsToCollect = 10; 
    public MissionBoots missionBoots; 
    private bool missionCompleted = false; 

    void Start()
    {
        
        missionBoots.UpdateBootText(bootsCollected, bootsToCollect);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!missionCompleted && other.CompareTag("Boot") && bootsCollected < bootsToCollect)
        {
            
            bootsCollected++;
            missionBoots.UpdateBootText(bootsCollected, bootsToCollect);
            Destroy(other.gameObject); 

            
            if (bootsCollected >= bootsToCollect)
            {
                
                Debug.Log("Botas recogidas, llévalas al ladrón");
                missionCompleted = true; 
            }
        }
    }
}
