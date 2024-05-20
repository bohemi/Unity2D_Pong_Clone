using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    [SerializeField] Transform _batRight = null;
    [SerializeField] float _batSpeed = 6f;
    [SerializeField] float _verticalLimits = 4.3f;
    [SerializeField] float _changeSpeedAtThisValue;

    private void Start()
    {
        _changeSpeedAtThisValue = 4;
    }

    private void Update()
    {
        MoveBat();
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

    void MoveBat()
    {
        if (Input.GetKey(KeyCode.UpArrow) && _batRight.position.y <= _verticalLimits)
        {
            _batRight.Translate(0, _batSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && _batRight.position.y >= -_verticalLimits)
        {
            _batRight.Translate(0, -_batSpeed * Time.deltaTime, 0);
        }
    }
}
