using UnityEngine;
using System;
public class EnemyScript : MonoBehaviour
{
    float speed = 1f;
    float direction = 1f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        rb.linearVelocityX = speed * direction;
    }

    public void DierctionChange()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x*-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }

    public void setDirection()
    {
        direction = -1 * direction;
    }
}
