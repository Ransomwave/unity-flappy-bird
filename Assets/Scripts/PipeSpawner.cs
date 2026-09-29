using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _randomYPadding = 7f;


    private float _cameraOrthographicSize;
    private Vector2 _cameraPosition;

    private float _cameraCenter;

    private float _cameraLeftEdge;
    private float _cameraRightEdge;

    private float _cameraTop;
    private float _cameraBottom;

    private float _spawnOffset = 2f;

    private Coroutine _spawnerCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _cameraOrthographicSize = Camera.main.orthographicSize;
        _cameraPosition = Camera.main.transform.position;

        _cameraCenter = _cameraOrthographicSize * Camera.main.aspect;
        _cameraLeftEdge = _cameraPosition.x - _cameraCenter;
        _cameraRightEdge = _cameraPosition.x + _cameraCenter;
        _cameraTop = _cameraPosition.y + _cameraCenter;
        _cameraBottom = _cameraPosition.y - _cameraCenter;

        // Resume(); // start the coroutine
    }

    void SpawnPipe() {
        var randomY = Random.Range(_cameraBottom + _randomYPadding, _cameraTop - _randomYPadding);

        // Quaternion.identity means no rotation
        Instantiate(_pipePrefab, new Vector3(_cameraRightEdge + _spawnOffset, randomY, 0f), Quaternion.identity);
    }

    IEnumerator SpawnPipes() {
        while (true) {
            yield return new WaitForSeconds(_spawnInterval);
            SpawnPipe();
        }
    }

    public void Resume() {
        if (_spawnerCoroutine != null) {
            print("Coroutine already running!");
            return;
        }
        _spawnerCoroutine = StartCoroutine(SpawnPipes());
    }

    public void Stop() {
        if (_spawnerCoroutine == null) {
            print("Coroutine already stopped!");
            return;
        }
        StopCoroutine(_spawnerCoroutine);
        _spawnerCoroutine = null;
    }
}
