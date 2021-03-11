using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    PlayerMover mover;
    Scene activeScene;


    private void Start()
    {
        mover = GetComponent<PlayerMover>();
        activeScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (activeScene.buildIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                mover.TryMoveUp();

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                mover.TryMoveDown();
        }
        else
        {
            float _horizontalInput = Input.GetAxis("Horizontal");
            mover.MoveRight(_horizontalInput);
        }
    }
}
