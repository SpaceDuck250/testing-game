using UnityEngine;

public class DumbEnemyScript : MonoBehaviour
{
    public Transform player;
    public float speed;

    private void Update()
    {
        Vector2 Direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //This method of movement is better because it doesnt override stuff like linear damping

    }
}
