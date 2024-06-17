using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isPlayerOne;
    void Start()
    {
        
    }

    void Update()
    {
        bool isPressingUp = Input.GetKey(_isPlayerOne? KeyCode.W : KeyCode.UpArrow);
        bool isPressingDown = Input.GetKey(_isPlayerOne? KeyCode.S : KeyCode.DownArrow);

        if (isPressingUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * _moveSpeed);
        }
        
        if (isPressingDown)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _moveSpeed);
        }
    }
}
