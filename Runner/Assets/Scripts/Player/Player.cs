using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage) 
    {
        _health -= damage;

        HealthChanged?.Invoke(_health);

        if (_health < 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NextLvlTrigger"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Die() 
    {
        Died?.Invoke();
    }
}
