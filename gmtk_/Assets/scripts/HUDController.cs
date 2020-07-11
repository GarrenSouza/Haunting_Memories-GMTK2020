using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text texto;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate() {
        int altura = Mathf.RoundToInt(playerTransform.position.y) + 21;
        texto.text = "Height: " + altura;
    }
}
