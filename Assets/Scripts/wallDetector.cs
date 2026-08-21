using UnityEngine;

public class wallDetector : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private EnemyScript enemyScript;
    void Start()
    {
        enemyScript = enemy.GetComponent<EnemyScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            enemy.transform.localScale = new Vector3(enemy.transform.localScale.x*-1,
                                                        enemy.transform.localScale.y,
                                                        enemy.transform.localScale.z);
            enemyScript.setDirection();
        }

    }
}