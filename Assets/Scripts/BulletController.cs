using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int velocidad;
    private Rigidbody2D _compRigidbody2D;
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        velocidad = 15;
    }
    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(0,velocidad);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
