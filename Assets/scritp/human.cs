using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Gerakan ke kiri
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        // Gerakan ke kanan
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        // Gerakan ke depan
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        // Gerakan ke belakang
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, 0, -speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Berhenti ketika tombol dilepas
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
