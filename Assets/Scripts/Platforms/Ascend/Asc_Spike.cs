﻿using UnityEngine;

public class Asc_Spike : MonoBehaviour
{
    public GameObject regularPlatform;
    private Rigidbody2D rb;

    void Awake()
    {
        regularPlatform.transform.parent = null;
    }   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // pause menu things idk
            }
        }
    }
}