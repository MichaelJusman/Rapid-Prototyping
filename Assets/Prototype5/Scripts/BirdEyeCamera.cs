using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEyeCamera : MonoBehaviour
{
    public Transform player; // The object the camera will follow
    public float distance = 10f; // The distance between the camera and the player
    public float height = 10f; // The height of the camera above the player
    public float angle = 45f; // The angle of the camera around the player

    void Update()
    {
        // Calculate the camera's position based on the player's position and the camera's distance, height, and angle
        Vector3 targetPosition = player.position + Vector3.up * height;
        Vector3 cameraPosition = targetPosition - Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        // Set the camera's position and look at the player
        transform.position = cameraPosition;
        transform.LookAt(player.position);
    }
}
