using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform cam;
    [Space]
    [Header("Must be in range (-1 to 1)")]
    [SerializeField] Vector2 parallaxEffect;

    Vector3 lastCameraPosition;

    private void Start()
    {
        lastCameraPosition = cam.position;
    }

    private void LateUpdate()
    {
        Vector3 _deltaMovment = cam.position - lastCameraPosition;
        transform.position += new Vector3( _deltaMovment.x * parallaxEffect.x, _deltaMovment.y * parallaxEffect.y);
        lastCameraPosition = cam.position;
    }
}
