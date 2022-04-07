using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Pattern
{
    LEFT_RIGHT,
    CIRCULAR_CLOCKWISE,
    CIRCULAR_COUNTERCLOCKWISE,
    EIGHT,
    INFINITY
}
public class EnnemyMovement : MonoBehaviour
{
    [SerializeField, Range(0, 3)] float _radius = 1;
    [SerializeField] float _speed = 1;
    [SerializeField] Pattern _movementPattern = Pattern.LEFT_RIGHT;
    Vector2 _initialPosition;
    float _initialTime;
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move((Time.time - _initialTime) * _speed);
    }
    void Move(float t)
    {
        switch (_movementPattern)
        {
            case Pattern.LEFT_RIGHT:
                MoveLeftRight(t);
                break;
            case Pattern.CIRCULAR_CLOCKWISE:
                MoveCircularClockWise(t);
                break;
            case Pattern.CIRCULAR_COUNTERCLOCKWISE:
                MoveCircularCounterClockWise(t);
                break;
            case Pattern.EIGHT:
                MoveEight(t);
                break;
            case Pattern.INFINITY:
                MoveInfinity(t);
                break;
            default:
                break;
        }
    }
    void MoveInfinity(float t)
    {
        transform.position = _initialPosition + new Vector2(Mathf.Sin(t), Mathf.Sin(t * 2)) * _radius;
    }
    void MoveEight(float t)
    {
        transform.position = _initialPosition + new Vector2(Mathf.Sin(t * 2), Mathf.Sin(t)) * _radius;
    }
    void MoveLeftRight(float t)
    {
        transform.position = _initialPosition + new Vector2(Mathf.Sin(t), 0) * _radius;
    }
    void MoveCircularClockWise(float t)
    {
        transform.position = _initialPosition + new Vector2(Mathf.Sin(t), Mathf.Cos(t)) * _radius;
    }
    void MoveCircularCounterClockWise(float t)
    {
        transform.position = _initialPosition + new Vector2(Mathf.Cos(t), Mathf.Sin(t)) * _radius;
    }
}
