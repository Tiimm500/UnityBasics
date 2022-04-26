using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float cameraHeight = 3f;
    [SerializeField] private float cameraDistance = 6f;

    // Update is called once per frame
    void Update()
    {
        Vector3 posPlayer = player.transform.position;
        posPlayer.y += cameraHeight;
        posPlayer.z -= cameraDistance;
        transform.position = posPlayer;
    }
}
