using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUp : MonoBehaviour
{
    public float velocidade = 1f;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 direction = transform.position;
        direction.y += velocidade;
        transform.position = direction;
    }
}
