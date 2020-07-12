using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject Camera;
    public float parallaxEffectMultiplier = 1f;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaMoviment = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMoviment * parallaxEffectMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
}