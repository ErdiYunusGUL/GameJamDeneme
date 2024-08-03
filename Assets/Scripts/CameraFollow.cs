using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (karakter)
    public float smoothSpeed = 0.125f; // Kameranýn takip hýzýný ayarlar
    public Vector3 offset; // Kameranýn karaktere olan konum farký

    public float boundaryX = 5f; // X eksenindeki sýnýr
    public float boundaryY = 3f; // Y eksenindeki sýnýr

    void LateUpdate()
    {
        // Hedefin ekranýn dýþýna çýkýp çýkmadýðýný kontrol et
        if (Mathf.Abs(target.position.x - transform.position.x) > boundaryX ||
            Mathf.Abs(target.position.y - transform.position.y) > boundaryY)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}


