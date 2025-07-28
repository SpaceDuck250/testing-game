using UnityEngine;

public class BullScript : MonoBehaviour
{
    public Vector3 anglevector;
    public Rigidbody2D rb;
    public float power = 5f;

    public float timer;

    private void Start()
    {

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check

        Destroy(gameObject);
    }
}
