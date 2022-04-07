using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 _direction = Vector2.zero;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        if (_rb)
        {
            _rb.velocity = _direction * _speed * Time.fixedDeltaTime;
        }
    }
}
