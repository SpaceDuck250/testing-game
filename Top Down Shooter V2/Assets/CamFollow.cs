using UnityEngine;
using UnityEngine.Apple;

public class CamFollow : MonoBehaviour
{
    public Transform playertransform;
    public Vector3 Offset = new Vector3(0, 0, -1);
    public float smoothvalue;

    private void FixedUpdate()
    {
        Vector3 destination = playertransform.position + Offset;

        transform.position = Vector3.Lerp(transform.position, destination, smoothvalue * Time.fixedDeltaTime);
    }
}
