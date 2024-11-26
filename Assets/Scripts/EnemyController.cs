using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int velocidad;
    public GameObject explosionPrefab;
    private GameManagerController gameManager;
    private Rigidbody2D _compRigidbody2D;
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(0, velocidad);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        tag = collision.gameObject.tag; 
        if (tag == "Wall")
        {
            gameManager.RestLives();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = collision.gameObject.tag;
        if (tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            gameManager.UpdatePoints(20);
            Destroy(this.gameObject);
        }
    }
    public void SetGameManager(GameManagerController gm)
    {
        gameManager = gm;
    }
}
