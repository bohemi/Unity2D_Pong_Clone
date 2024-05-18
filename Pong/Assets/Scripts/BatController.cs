using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    [SerializeField] Transform _batRight = null;
    [SerializeField] float _rightSpeed = 6f;
    [SerializeField] float _verticalLimits = 4.3f;

    private void Update()
    {
        MoveBat();
    }

    void MoveBat()
    {
        if (Input.GetKey(KeyCode.UpArrow) && _batRight.position.y <= _verticalLimits)
        {
            _batRight.Translate(0, _rightSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && _batRight.position.y >= -_verticalLimits)
        {
            _batRight.Translate(0, -_rightSpeed * Time.deltaTime, 0);
        }
    }
}
