using UnityEngine;

public class DestroyByColliderCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyMovement enemy))
        {
            Destroy(enemy.gameObject);
        }
    }

}
