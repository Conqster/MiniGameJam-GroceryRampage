using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    public static bool isCollected = false;
    private void Awake()
    {
        GlobalEventManager.OnGroceryCollected.AddListener(ChangeColour);
        GlobalEventManager.OnGroceryDelivered.AddListener(DeliveredGrocery);
    }

    void ChangeColour(int item)
    {
        if (item == 1)
        {
            _renderer.color = Color.blue;
            isCollected = true;
        }
        else
        {

        }
    }

    void DeliveredGrocery()
    {
        _renderer.color = Color.red;
        isCollected = false;
    }
}
