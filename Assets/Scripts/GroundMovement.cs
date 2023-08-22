using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 6f;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _startSize;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        var size = _spriteRenderer.size;
        _startSize = new Vector2(size.x, size.y);
    }

    private void Update()
    {
        var size = _spriteRenderer.size;
        size = new Vector2(size.x + speed * Time.deltaTime,
            size.y);
        _spriteRenderer.size = size;

        if (_spriteRenderer.size.x > width)
        {
            _spriteRenderer.size = _startSize;
        }
    }
}
