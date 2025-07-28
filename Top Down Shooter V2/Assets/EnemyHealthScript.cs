using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public EnemyScript enemy;
    public float health = 3;
    public GameObject bloody;

    private void Start()
    {
        bloody = Resources.Load<GameObject>("Splatter Particles");
  
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;

            Instantiate(bloody, transform.position, Quaternion.identity);

            enemy.AggroRange = enemy.TriggeredRange;
            enemy.currentstate = EnemyScript.States.Aggro;

            if (health <= 0)
            {
                SpawningScriptorino.instance.OnEnemyDestroyed?.Invoke();
                Destroy(gameObject);
            }

        }
    }
}
