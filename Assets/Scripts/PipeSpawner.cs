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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _cameraOrthographicSize = Camera.main.orthographicSize;
        _cameraPosition = Camera.main.transform.position;

        _cameraCenter = _cameraOrthographicSize * Camera.main.aspect;
        _cameraLeftEdge = _cameraPosition.x - _cameraCenter;
        _cameraRightEdge = _cameraPosition.x + _cameraCenter;
        _cameraTop = _cameraPosition.y + _cameraCenter;
        _cameraBottom = _cameraPosition.y - _cameraCenter;

        StartCoroutine(SpawnPipes());
    }

    void SpawnPipe() {
        var randomY = Random.Range(_cameraBottom + _randomYPadding, _cameraTop - _randomYPadding);

        // Quaternion.identity means no rotation
        Instantiate(_pipePrefab, new Vector3(_cameraRightEdge, randomY, 0f), Quaternion.identity);

        print("Spawning pipe at: " + randomY);

        // var pipeCloneRigidbody = pipeClone.GetComponent<Rigidbody2D>();
    }

    IEnumerator SpawnPipes() {
        while (true) {
            yield return new WaitForSeconds(_spawnInterval);
            SpawnPipe();
        }
    }
}
