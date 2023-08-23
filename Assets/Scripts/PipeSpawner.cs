using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject pipePoolParent;

    private float _timer;
    [Inject] private UIHandler _uiHandler;

    private void Start()
    {
        InitSpawnParams();
        _uiHandler.onDifficultyChanged.AddListener(InitSpawnParams);
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
        GameObject pipe = gameObject;
        
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, +heightRange));
        foreach (Transform child in pipePoolParent.transform)
        {
            if (!child.gameObject.activeInHierarchy)
            {
                pipe = child.gameObject;
                break;
            }
        }

        if (pipe == gameObject) return;
        pipe.transform.position = spawnPos;
        pipe.SetActive(true);
    }

    private void InitSpawnParams()
    {
        maxTime = _uiHandler.currentDifficulty.timeToSpawn;
        heightRange = _uiHandler.currentDifficulty.middleDistance;
    }
}
