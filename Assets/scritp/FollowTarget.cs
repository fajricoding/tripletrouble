using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;  // Objek yang akan diikuti (misalnya, karakter)
    public Vector3 offset;    // Jarak antara kamera dan objek target

    void Start()
    {
        // Menentukan offset awal antara kamera dan objek target
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        float smoothSpeed = 0.125f; // Semakin kecil nilai, semakin halus gerakan
Vector3 desiredPosition = target.position + offset;
Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
transform.position = smoothedPosition;

        // Update posisi kamera agar mengikuti target dengan offset
        if (target != null)
        {
            transform.position = target.position + offset;
        }

    }
}
