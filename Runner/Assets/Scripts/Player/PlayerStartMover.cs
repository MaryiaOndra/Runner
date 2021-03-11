using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartMover : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveRight();
    }

    void MoveRight() 
    {


        float _horizInput = Input.GetAxis("Horizontal");

        var _velocity = playerRb.velocity;
        _velocity.x = Vector2.right.x * _horizInput * speed;
        playerRb.velocity = _velocity;
    }
}
