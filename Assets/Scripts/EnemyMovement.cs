using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Transform _transform;
    private Transform _targetTrasform;

    private void Start()
    {
        _transform = transform;
        _targetTrasform = GetComponentInParent<SpawnMachine>().transform;
    }
    
    void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _targetTrasform.position, _speed * Time.deltaTime);
    }
}
