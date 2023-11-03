using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float h = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float v = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += new Vector3(h, v, 0);
    }
}