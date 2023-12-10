using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _compRigidbody2D;
    private SpriteRenderer _compSpriteRend;
    public SFXController sfxController;
    public GameObject bulletPrefab;
    public int velocidad;
    private float direccionHorizontal;
    private float direccionVertical;
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _compSpriteRend = GetComponent<SpriteRenderer>();
        velocidad = 8;
    }
    void Update()
    {
        direccionHorizontal = Input.GetAxis("Horizontal");
        direccionVertical = Input.GetAxis("Vertical");
        if (direccionHorizontal < 0)
        {
            _compSpriteRend.flipX = true;
        }
        else if (direccionHorizontal > 0)
        {
            _compSpriteRend.flipX = false;
        }
        Shoot();
    }
    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(velocidad * direccionHorizontal,velocidad * direccionVertical);
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            sfxController.PlayLaserBeamEffect();
            Instantiate(bulletPrefab,transform.position,transform.rotation);
        }
    }
}
