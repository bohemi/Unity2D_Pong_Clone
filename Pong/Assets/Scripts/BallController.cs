using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public static int scoreCountLeft { get; private set; }
    public static int scoreCountRight { get; private set; }

    [SerializeField] private float _horizontalSpeed = 200f;
    [SerializeField] private float _increaseSpeed = 0.2f; // keeps on increasing during the play
    Rigidbody2D _rigidBody = null;

    int _initialDirection = 0;

    private void Start()
    {
        scoreCountLeft = scoreCountRight = 0;
        _rigidBody = GetComponent<Rigidbody2D>();
        _increaseSpeed = 0.2f;
        _initialDirection = Random.Range(1, 3);
        Invoke("InitBall", 2.0f);
    }

    private void InitBall()
    {
        if (_initialDirection == 1)
        {
            _rigidBody.AddForce(Vector2.right * _horizontalSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            _rigidBody.AddForce(Vector2.up * _horizontalSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        if (_initialDirection == 2)
        {
            _rigidBody.AddForce(Vector2.left * _horizontalSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            _rigidBody.AddForce(Vector2.down * _horizontalSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerLeft")
        {
            _rigidBody.AddForce(Vector2.right * _increaseSpeed, ForceMode2D.Impulse);
            scoreCountLeft++;
        }
        else if (collision.gameObject.tag == "PlayerRight")
        {
            _rigidBody.AddForce(Vector2.left * _increaseSpeed, ForceMode2D.Impulse);
            scoreCountRight++;
        }

        if (collision.gameObject.tag == "Walls")
        {
            SceneManager.LoadSceneAsync("Play Scene");
        }
    }
}
