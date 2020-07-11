using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private float _tempoEsperado = 3.0f;
    private float _timer = 0; 
    private CharacterController _controller;

    public float _countSomething = 0;

    public float base_delay;
    public float limit_delay;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (!_controller)
            Debug.LogError("Controller is null!");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovimentaUsGuri();       
    }

    void MovimentaUsGuri()
    {
        // movimento horizontal :
        float HorizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(HorizontalInput, 0, 0);     
        Vector3 movement = direction * _playerSpeed;

        // verifica se tem chão :
        if (!_controller.isGrounded)
            _yVelocity -= _gravity;

        // contador :
        _timer += Time.deltaTime;

        
        if(_timer >= _tempoEsperado && _controller.isGrounded)
        {
            _yVelocity = _jumpHeight;               // pula
            _tempoEsperado = Random.Range(base_delay, limit_delay);    // tempo para o próximo pulo
            _timer = 0;                             // reinicia o contador
        }


        // alteração no movimento do jogador :
        movement.y = _yVelocity;                    
        _controller.Move(movement * Time.deltaTime);        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Coletavel") {
            _countSomething++;
            _jumpHeight = _jumpHeight + 5f;
            Destroy(other.gameObject);
        }

        if (other.tag == "coletavel2")
        {
            _countSomething++;
            _jumpHeight = 15f;
            Destroy(other.gameObject);
        }
    }


}
