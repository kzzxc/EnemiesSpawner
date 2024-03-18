using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Transform _target;
    private Vector3 _lastPosition;

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        if (_target != null)
        {
            var targetPosition = _target.position;
            var distance = 0.2f;

            if (Vector2.Distance(transform.position, targetPosition) > distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            }
        }
    }
}