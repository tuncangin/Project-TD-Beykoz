using DG.Tweening;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public int damage = 5;
    private Transform target;

    private PoolHandler _poolHandler;
    private Tweener moveTweener;

    public void Init(PoolHandler poolHandler)
    {
        _poolHandler = poolHandler;
    }

    public void Fire(Transform targetTransform)
    {
        target = targetTransform;
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (target == null)
        {
            ReturnToPool();
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);
        float duration = distance / speed;

        moveTweener = transform.DOMove(target.transform.position, duration).SetEase(Ease.Linear).OnComplete(HitTarget);
    }

    private void HitTarget()
    {
        if (target!=null)
        {
            target.gameObject.GetComponent<Enemy>().GetDamage(damage);
        }
        
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        if (moveTweener != null && moveTweener.IsActive())
        {
            moveTweener.Kill();
        }
        
        _poolHandler.ReturnProjectileToPool(gameObject);
    }
}
