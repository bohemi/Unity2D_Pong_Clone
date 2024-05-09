using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    [SerializeField] Transform bat_left = null;
    [SerializeField] Transform bat_right = null;
    [SerializeField] float left_speed = 0.0f;
    [SerializeField] float right_speed = 0.0f;
    [SerializeField] float vertical_limits = 4.3f;

    private void Update()
    {
        MoveBat();
    }

    void MoveBat()
    {
        if (Input.GetKey(KeyCode.W) && bat_left.position.y <= vertical_limits)
        {
            bat_left.Translate(0, left_speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.S) && bat_left.position.y >= -vertical_limits)
        {
            bat_left.Translate(0, -left_speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) && bat_right.position.y <= vertical_limits)
        {
            bat_right.Translate(0, right_speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && bat_right.position.y >= -vertical_limits)
        {
            bat_right.Translate(0, -right_speed * Time.deltaTime, 0);
        }
    }
}
