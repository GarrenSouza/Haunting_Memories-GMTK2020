using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate() {
        Vector3 temp = transform.position;
        if (playerTransform.position.y > -12) {
            temp.y = playerTransform.position.y;
        }

        transform.position = temp;  
    }
}
