using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public float speed;
    public GameObject audio_JLN;

    void Start(){
        audio_JLN.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
  
        // Gerakan ke kiri
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            audio_JLN.SetActive(true);
        }
        // Gerakan ke kanan
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            audio_JLN.SetActive(true);
        }
        // Gerakan ke depan
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            audio_JLN.SetActive(true);
        }
        // Gerakan ke belakang
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, 0, -speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            audio_JLN.SetActive(true);
        }

        // Berhenti ketika tombol dilepas
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            audio_JLN.SetActive(false);
        }
    }
}
