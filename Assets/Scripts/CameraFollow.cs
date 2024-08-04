using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public float smoothX;

     void Start()
    {
        player = GameObject.Find("Player").transform;  
    }

     void LateUpdate()
    {
        float posX = Mathf.MoveTowards(transform.position.x, player.position.x, smoothX);
        transform.position = new Vector3(posX, transform.position.y,transform.position.z);  
    }
}


