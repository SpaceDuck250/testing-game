using UnityEngine;

public class TurnScript : MonoBehaviour
{
    public void TurnToTarget(Vector3 target)
    {
        Vector3 anglevector = (target - transform.position).normalized;
        float angle = Mathf.Atan2(anglevector.y, anglevector.x) * Mathf.Rad2Deg;
        Quaternion Qangle = Quaternion.Euler(0, 0, angle);
        transform.rotation = Qangle;
    }
}
