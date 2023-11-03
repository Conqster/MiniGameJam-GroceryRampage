using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class UiManager : MonoBehaviour
{
    [SerializeField] private int deliveredItems;
    [SerializeField] private TextMeshProUGUI deliveredText;
    // Start is called before the first frame update
    private void Awake()
    {
        GlobalEventManager.OnGroceryCollected.AddListener(UpdateCollectedText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCollectedText(int item)
    {
        deliveredItems += item;
        deliveredText.text = "Collected: " + deliveredItems;
    }
}
