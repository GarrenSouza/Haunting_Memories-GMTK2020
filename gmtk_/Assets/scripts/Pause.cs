using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pausePane;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start() {
        pausePane.SetActive(isPaused);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pausePane.activeInHierarchy) {
                PauseGame();
            }
            else {
                ContinueGame();
            }
        }
    }

    private void PauseGame() {
        Time.timeScale = 0;
        isPaused = true;
        pausePane.SetActive(isPaused);
    }

    private void ContinueGame() {
        Time.timeScale = 1;
        isPaused = false;
        pausePane.SetActive(isPaused);
    }
}