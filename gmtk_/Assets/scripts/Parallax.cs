using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{

//  Parallax do Marco   : 
 
    private float _length, _startPos;
    public float parallaxEffect;
    private GameObject _cam;

    void Start()
    {
        _startPos = transform.position.y;
        _length = GetComponent<SpriteRenderer>().bounds.size.y;
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        float temp = (_cam.transform.position.y * (1 - parallaxEffect));
        float dist = (_cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, _startPos + dist, transform.position.z);

        if (temp > _startPos + _length) _startPos += _length;
        else if (temp < _startPos - _length) _startPos -= _length;
    }
}
