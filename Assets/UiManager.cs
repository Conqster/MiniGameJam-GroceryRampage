using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class UiManager : MonoBehaviour
{
    [SerializeField] private int deliveredItems = 0;

    [SerializeField] private TextMeshProUGUI deliveredText;

    // Start is called before the first frame update
    private void Awake()
    {
        GlobalEventManager.OnGroceryDelivered.AddListener(UpdateCollectedText);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateCollectedText()
    {
        deliveredItems += 1;
        deliveredText.text = "Delivered: " + deliveredItems;
    }
}