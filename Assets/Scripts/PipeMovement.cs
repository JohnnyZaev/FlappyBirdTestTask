using UnityEngine;
using Zenject;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;

    private Vector3 _startPos;
    [Inject] private UIHandler _uiHandler;


    private void Awake()
    {
        _startPos = transform.position;
        _uiHandler.onDifficultyChanged.AddListener(ChangeSpeed);
    }

    private void OnEnable()
    {
        transform.position = _startPos;
        ChangeSpeed();
    }

    private void Update()
    {
        if (transform.position.x < -3f)
            gameObject.SetActive(false);
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
    }

    private void ChangeSpeed()
    {
        speed = _uiHandler.currentDifficulty.pipeSpeed;
    }
}
