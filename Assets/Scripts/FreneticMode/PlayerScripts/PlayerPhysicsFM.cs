using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsFM : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.freezeRotation = true;
    }
}
