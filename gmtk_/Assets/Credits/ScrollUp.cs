using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollUp : MonoBehaviour
{
    public float velocidade = 1f;
    public float maxY;
    public float timer = 0f;
    public GameObject Fader;

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 direction = transform.position;
        if (timer > 20f)
            StartCoroutine(espere());
        else
        {
            direction.y += velocidade;
            transform.position = direction;
        }

        
    }

    void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
    }

    IEnumerator espere()
    {
        yield return new WaitForSeconds(3);
        Fader.GetComponent<levelChanger5>().FadeToLevel("Jogo");
    }


}
