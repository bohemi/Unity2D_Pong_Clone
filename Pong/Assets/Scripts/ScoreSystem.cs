using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _leftTextScore;
    [SerializeField] TextMeshProUGUI _rightTextScore;

    private void Awake()
    {
        if (!_leftTextScore || !_rightTextScore)
        {
            Debug.LogError("Texts are null", this);
        }
    }

    private void Update()
    {
        _leftTextScore.text = BallController.scoreCountLeft.ToString();
        _rightTextScore.text = BallController.scoreCountRight.ToString();
    }
}
