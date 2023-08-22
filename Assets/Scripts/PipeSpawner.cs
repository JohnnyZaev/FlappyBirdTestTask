using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject pipePrefab;

    private float _timer;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (_timer > maxTime)
        {
            SpawnPipe();
            _timer = 0f;
        }

        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, +heightRange));
        var pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
        
        Destroy(pipe, 10f);
    }
}
