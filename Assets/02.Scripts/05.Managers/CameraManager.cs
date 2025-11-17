using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float height = 2.0f;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private float rotationSpeed = 5.0f;

    private float currentAngleX = 0.0f;
    private float currentAngleY = 20.0f;

    [SerializeField] private float minAngleY = -10.0f;
    [SerializeField] private float maxAngleY = 60.0f;

    private void Awake()
    {
        if (player == null) 
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void LateUpdate()
    {
        currentAngleX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentAngleY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentAngleY = Mathf.Clamp(currentAngleY, minAngleY, maxAngleY);

        Quaternion rotation = Quaternion.Euler(currentAngleY, currentAngleX, 0.0f);
        
        Vector3 targetPosition = player.position 
            - rotation * Vector3.forward * distance
            + Vector3.up * height;

        transform.position = Vector3.Slerp(transform.position, targetPosition, smoothSpeed);

        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
