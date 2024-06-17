using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _startingSpeed;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _impactSound;
    [SerializeField] private AudioClip _scoreSound;

    private float xVelocity;
    private float yVelocity;
    void Start()
    {
        RandomVelocity();
    }

    private void RandomVelocity()
    {
        bool isRight = UnityEngine.Random.value >= 0.5;

        xVelocity = isRight ? 1f : -1f;

        yVelocity = UnityEngine.Random.Range(-1, 1);
        _rb.velocity = Vector2.zero;
        _rb.velocity = new Vector2(xVelocity * _startingSpeed, yVelocity * _startingSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Border"))
        {
            PlayScoreSound();
            GameController score = FindObjectOfType<GameController>();
            score.AddPoint(_rb.velocity.x >= 0);
        }
        else if(col.gameObject.CompareTag("Paddle"))
        {
            PlayImpactSound();
        }
    }

    private void PlayImpactSound()
    {
        _audioSource.clip = _impactSound;
        _audioSource.Play();    
    }

    private void PlayScoreSound()
    {
        _audioSource.clip = _scoreSound;
        _audioSource.Play();
    }

}
