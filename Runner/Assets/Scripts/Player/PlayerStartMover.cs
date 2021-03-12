using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NextLvlTrigger"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
