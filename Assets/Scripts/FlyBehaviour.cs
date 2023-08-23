using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Zenject;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody2D _playerRigidbody2D;
    [Inject] private UIHandler _uiHandler;
    [Inject] private AudioHandler _audioHandler;
    [Inject] private CanvasHitDetector _canvasHitDetector;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        Touch.onFingerDown += MoveUp;
    }

    private void OnDisable()
    {
        Touch.onFingerDown -= MoveUp;
        EnhancedTouchSupport.Disable();
    }

    private void Awake()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _playerRigidbody2D.velocity.y * rotationSpeed);
    }

    private void MoveUp(Finger finger)
    {
        if (_canvasHitDetector.IsPointerOverUI())
            return;
        if (Time.timeScale == 0f)
            _uiHandler.StartGame();
        _playerRigidbody2D.velocity = Vector2.up * velocity;
        _audioHandler.PlaySound(AudioHandler.Sounds.Wing);
    }

    private void OnCollisionEnter2D()
    {
        _uiHandler.GameOver();
        _audioHandler.PlaySound(AudioHandler.Sounds.Hit);
        enabled = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _uiHandler.UpdateScore();
        _audioHandler.PlaySound(AudioHandler.Sounds.Point);
    }
}
