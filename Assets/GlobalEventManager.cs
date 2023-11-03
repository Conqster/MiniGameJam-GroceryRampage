using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent<int> OnGroceryCollected = new UnityEvent<int>();
    public static UnityEvent OnGroceryDelivered = new UnityEvent();

    public static void SendGroceryCollected(int item)
    {
        OnGroceryCollected.Invoke(item);
    }

    public static void SendGroceryDelivered()
    {
        OnGroceryDelivered.Invoke();
    }
}