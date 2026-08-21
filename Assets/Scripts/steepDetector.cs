using UnityEngine;

public class steepDetector : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private EnemyScript enemyScript;
    void Start()
    {
        enemyScript = enemy.GetComponent<EnemyScript>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        enemy.transform.localScale = new Vector3(enemy.transform.localScale.x*-1,
                                                      enemy.transform.localScale.y,
                                                      enemy.transform.localScale.z);
        enemyScript.setDirection();
    }
}
