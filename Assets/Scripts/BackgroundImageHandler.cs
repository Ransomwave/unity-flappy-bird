using UnityEngine;

public class BackroundImageHandler : MonoBehaviour {

    [SerializeField] private float _speed;

    private float _startX;

    private SpriteRenderer _spriteRenderer;
    private float _distanceTravelled = 0;
    private float _tileWidth;

    void Awake() {
        var cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        var cameraLeftEdge = Camera.main.transform.position.x - cameraHalfWidth;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _tileWidth = _spriteRenderer.sprite.bounds.size.x;

        _startX = cameraLeftEdge + _tileWidth;
    }

    // Update is called once per frame
    void Update() {
        _distanceTravelled += _speed * Time.deltaTime;

        var newX = _startX - Mathf.Repeat(_distanceTravelled, _tileWidth);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
