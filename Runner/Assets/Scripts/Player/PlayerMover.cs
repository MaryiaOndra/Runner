using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float stepSize;
    [SerializeField] float maxHeight;
    [SerializeField] float minHeight;

    Vector3 targetPos;
    Scene activeScene;
    Rigidbody2D playersRb;

    private void Awake()
    {
        targetPos = transform.position;
        activeScene = SceneManager.GetActiveScene();
        playersRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (activeScene.buildIndex != 0)
        {
            MoveForward();
            Debug.Log("MoveForward");
        }
    }

    void MoveForward() 
    {
        if (transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    public void TryMoveUp() 
    {
        Debug.Log("TryMoveUp");
        if (targetPos.y < maxHeight)
            SetNextPosition(stepSize);
    }

    public void TryMoveDown()
    {
        Debug.Log("TryMoveDown");
        if (targetPos.y > minHeight)
            SetNextPosition(-stepSize);
    }

    public void MoveRight(float horizInput) 
    {
        Debug.Log("MoveRight");

        var _velocity = playersRb.velocity;
        _velocity.x = Vector2.right.x * horizInput * moveSpeed;
        playersRb.velocity = _velocity;
    }

    private void SetNextPosition(float stepSize) 
    {
        targetPos = new Vector2(targetPos.x, targetPos.y + stepSize);
    }
}
