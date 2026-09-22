using UnityEngine;

public class PipeHandler : MonoBehaviour {

    [SerializeField] private float _moveSpeed = 10f;

    private Rigidbody2D _rigidbody2D;

    private float _cameraHalfWidth;
    private float _cameraLeftEdge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        _cameraLeftEdge = Camera.main.transform.position.x - _cameraHalfWidth;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        _rigidbody2D.MovePosition(new Vector2(_rigidbody2D.position.x - _moveSpeed * Time.deltaTime, _rigidbody2D.position.y));
        if (_rigidbody2D.position.x < _cameraLeftEdge - 5) {
            Destroy(gameObject);
        }
    }
}
