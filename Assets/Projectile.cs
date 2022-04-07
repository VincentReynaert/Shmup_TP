using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Emmiter
{
    PLAYER,
    ENNEMY
}
public class Projectile : MonoBehaviour
{
    public Emmiter MyEmmiter;
    [SerializeField] float _speed = 1;
    [SerializeField] int _damages = 10;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb) _rb.velocity = transform.up * _speed * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player" & MyEmmiter == Emmiter.PLAYER) | (collision.tag == "Ennemy" & MyEmmiter == Emmiter.ENNEMY)) return;
        else if (collision.tag == "MainCamera") Destroy(gameObject);
        LivingEntity target;
        bool collisionIsLivingEntity = collision.TryGetComponent<LivingEntity>(out target);
        if (collisionIsLivingEntity)
        {
            Debug.Log("Hit : " + collision.name);
            target.GetHit(_damages);
        }
        //Destroy(gameObject);
    }
}
