using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemiesPlayer : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10.0f)] private float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;
    }
}
