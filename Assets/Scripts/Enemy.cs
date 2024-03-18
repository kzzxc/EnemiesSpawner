using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector2 _direction;

    private void Update()
    {
        Move();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }
    
    private void Move()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime));
    }
}
