using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{

    public Transform player;
    public Vector3 offSet;
    [Range(1, 10)]
    public float smoothness;


    private void FixedUpdate(){
        FollowPlayer();
    }

    void FollowPlayer(){
        Vector3 cameraPosition = player.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
