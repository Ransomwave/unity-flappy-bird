using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour {
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private InputActionReference _jumpActionReference;

    [SerializeField] private LevelHandler _levelHandler;

    private Rigidbody2D _rigidbody2D;

    public event Action OnPointScored;

    // My methods
    void Jump(InputAction.CallbackContext context) {
        _rigidbody2D.linearVelocity = Vector2.zero; // Reset the velocity before applying the jump force
        _rigidbody2D.AddForceY(_jumpForce, ForceMode2D.Impulse);
    }


    // Unity methods
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        _jumpActionReference.action.performed += Jump;
    }

    void OnDisable() {
        _jumpActionReference.action.performed -= Jump;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        print($"Bird collided with: {collision.gameObject.name}");
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // print($"Bird collided with trigger: {collision.gameObject.name}");
        OnPointScored.Invoke();
    }
}
