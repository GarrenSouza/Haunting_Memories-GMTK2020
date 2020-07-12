using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField]
    private float _playerSpeed = 5f;
    [SerializeField]
    private float _gravity = 1.0f;
    public float _jumpHeight = 15.0f;
    [SerializeField]
    private float _jumpHeightOriginal = 15.0f;
    private float _yVelocity;
    private float _tempoEsperado = 3.0f;
    private float _timer = 0;
    private CharacterController _controller;

    public float base_delay;
    public float limit_delay;

    // Start is called before the first frame update
    void Start() {
        _controller = GetComponent<CharacterController>();
        if (!_controller)
            Debug.LogError("Controller is null!");
    }

    // Update is called once per frame
    void FixedUpdate() {
        MovimentaUsGuri();
    }

    void MovimentaUsGuri() {
        // movimento horizontal :
        float HorizontalInput = Input.GetAxis("Horizontal");
        if (HorizontalInput < 0) {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (HorizontalInput > 0) {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        Vector3 direction = new Vector3(HorizontalInput, 0, 0);
        Vector3 movement = direction * _playerSpeed;

        // verifica se tem chão :
        if (!_controller.isGrounded)
            _yVelocity -= _gravity;

        // contador :
        _timer += Time.deltaTime;


        if (_timer >= _tempoEsperado && _controller.isGrounded) {
            SoundManager.instance.JumpSound();
            _yVelocity = _jumpHeight;               // pula
            _tempoEsperado = Random.Range(base_delay, limit_delay);    // tempo para o próximo pulo
            _timer = 0;                             // reinicia o contador
        }


        // alteração no movimento do jogador :
        movement.y = _yVelocity;
        _controller.Move(movement * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        string descricao = "";
        if (other.tag == "Coletavel") {
            SoundManager.instance.EnergySound();
            _jumpHeight += 5f;
            descricao = "+5 Jump Power";
            Destroy(other.gameObject);
        }
        if (other.tag == "coletavel2") {
            SoundManager.instance.EnergySound();
            _jumpHeight = _jumpHeightOriginal;
            descricao = "Jump Power Reset";
            Destroy(other.gameObject);
        }
        if (other.tag == "ganhou_tag") {
            new Pause().Credits();
            descricao = "You win";
            Destroy(other.gameObject);
        }

        GameObject.FindGameObjectWithTag("DescricaoColetavel").GetComponent<Text>().text = descricao;
        GameObject.FindGameObjectWithTag("SpriteColetavel").GetComponent<Image>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
    }
}
