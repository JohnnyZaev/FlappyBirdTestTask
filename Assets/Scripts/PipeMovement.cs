using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;

    private void Update()
    {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
    }
}
