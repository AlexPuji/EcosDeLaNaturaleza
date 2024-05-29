using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjectsManager : MonoBehaviour
{
    private static InteractionObjectsManager instance;
    private List<GameObject> interactionObjects = new List<GameObject>();

    public static InteractionObjectsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InteractionObjectsManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(InteractionObjectsManager).Name);
                    instance = singletonObject.AddComponent<InteractionObjectsManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void RegisterInteractionObject(GameObject interactionObject)
    {
        if (!interactionObjects.Contains(interactionObject))
        {
            interactionObjects.Add(interactionObject);
        }
    }

    public void UnregisterInteractionObject(GameObject interactionObject)
    {
        if (interactionObjects.Contains(interactionObject))
        {
            interactionObjects.Remove(interactionObject);
        }
    }

}
