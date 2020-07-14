using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChanger5 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private string sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            FadeToLevel("Jogo");
    }

    public void FadeToLevel (string name)
    {
        sceneToLoad = name;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

