using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] GameObject _ballObj;
    [SerializeField] bool _activateBat;
    [SerializeField] float _batSpeed = 6f;
    [SerializeField] float _changeSpeedAtThisValue;

    Vector2 _ballPosition;

    private void Start()
    {
        _changeSpeedAtThisValue = 4;
        _activateBat = true;
    }

    private void Update()
    {
        _ballPosition = _ballObj.transform.position;

        if (_activateBat && _ballPosition.y <= 4.25f && _ballPosition.y >= -4.25f)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-10.77f, _ballPosition.y), _batSpeed * Time.deltaTime);
        }

        if (_ballPosition.x >= 10.0f)
        {
            _activateBat = true;
        }

        ChangeBatSpeed(1);
    }

    void ChangeBatSpeed(float speed)
    {
        if (BallController.scoreCountLeft + BallController.scoreCountRight == _changeSpeedAtThisValue)
        {
            _changeSpeedAtThisValue += _changeSpeedAtThisValue;
            _batSpeed += speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            _activateBat = false;
        }
    }
}
