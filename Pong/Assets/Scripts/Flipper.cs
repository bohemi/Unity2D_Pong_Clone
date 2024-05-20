using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] Transform _bat;
    [SerializeField] Transform _ball;
    [SerializeField] Vector3 _rotateAmount;
    [SerializeField] float _speed;
    [SerializeField] float _distance;
    [SerializeField] float _resetFlipTime;
    [SerializeField] bool _shouldFlip, _doNotMultipleFlip;

    private void Start()
    {
        if (!_bat || !_ball)
        {
            Debug.LogError("Flippers", this);
        }
    }

    private void Update()
    {
        if (_ball.position.x >= _distance)
        {
            _bat.localEulerAngles = Vector3.zero;

            // doNotMultipleFlip will prevent flipping more than once by getting true only coming to this block
            // which will happen only when the ball gets hit by the bat. and then the shouldFlip will be false
            _doNotMultipleFlip = true;
            _shouldFlip = false;
        }
        else
        {
            _shouldFlip = true;
        }

        if (_shouldFlip && _doNotMultipleFlip)
        {
            DoTheFlip(_bat, _ball, _rotateAmount);
        }
    }

    void DoTheFlip(Transform bat, Transform ball, Vector3 rotateValue)
    {
        int decideUpDownFlipper = Random.Range(0, 2);

        if (decideUpDownFlipper < 1)
        {
            bat.localEulerAngles = rotateValue;
        }
        else
            bat.localEulerAngles = new Vector3(0, 0, 5);

        _doNotMultipleFlip = false;
    }
}