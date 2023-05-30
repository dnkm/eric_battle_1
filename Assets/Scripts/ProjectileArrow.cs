using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    private Transform target, origin;
    private Vector3 targetPos, originPos;
    private float flyingSpeed = 40f;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    private bool hasHit;
    private float arrowDamage;
    private int groupNum;

    void Update()
    {
        if (hasHit)
        {
            return;
        }
        
        dist = targetPos.x - originPos.x;
        
        nextX = Mathf.MoveTowards(transform.position.x, targetPos.x, flyingSpeed * Time.deltaTime);
        baseY = Mathf.Lerp(originPos.y, targetPos.y, (nextX - originPos.x) / dist);
        height = 2 * (nextX - originPos.x) * (nextX - targetPos.x) / (-0.25f * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        
        float distance = Vector3.Distance(transform.position, targetPos);
        if (distance < 0.25f && !hasHit)
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }
            hasHit = true;
            performDamage(target);
        }
    }

    public void setTarget(Transform _target, Transform _origin, int _groupNum, float _damage)
    {
        target = _target;
        targetPos = new Vector3(target.position.x, target.position.y, target.position.z);
        origin = _origin;
        originPos = new Vector3(origin.position.x, origin.position.y, origin.position.z);
        groupNum = _groupNum;
        arrowDamage = _damage;
    }

    private static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

    private void performDamage(Transform _target)
    {
        //float newArrowPos = transform.position.x > 0 ? transform.position.x - 0.35f : transform.position.x +0.35f;
        float newArrowRot = transform.position.x < 0 ? Random.Range(-75.0f, -45.0f) : Random.Range(-130f, -100f);

        transform.position = new Vector3(_target.position.x, transform.position.y+ 0.25f, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, newArrowRot);
        transform.parent = _target;
        Destroy(gameObject, 2f);

        _target.GetComponent<BaseUnit>().updateDamage(arrowDamage);
        FindObjectOfType<FXMaster>().Arrow(_target, _target.position.x > transform.position.x ? 1 : -1, arrowDamage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        float distance = Vector3.Distance(other.transform.position, originPos);

        if (distance < 1f)
        {
            return;
        }

        if (other.GetComponent<BaseUnit>() != null && !hasHit)
        {
            if (groupNum != other.GetComponent<BaseUnit>().groupNum)
            {
                hasHit = true;
                //print("HIT by OnTriggerEnter2D ");
                performDamage(other.transform);
            }
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     float distance = Vector3.Distance (other.transform.position, origin.transform.position);
    //
    //     if (distance < 1f)
    //     {
    //         return;
    //     }
    //
    //     if (hasHit){
    //     
    //         
    //         if (other.GetComponent<BaseUnit>() != null)
    //         {
    //             print("ARROW Trigger Enter: " + distance);
    //             other.GetComponent<BaseUnit>().updateDamage(arrowDamage);
    //             FindObjectOfType<FXMaster>().Arrow(other.transform, other.transform.position.x > transform.position.x ? 1 : -1, arrowDamage);
    //         }
    //     }
    // }
}