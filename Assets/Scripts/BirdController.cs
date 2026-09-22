using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour {
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private InputActionReference _jumpActionReference;

    private Rigidbody2D _rigidbody2D;

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

    private void OnCollisionEnter2D(Collision2D collision) {
        print($"Bird collided with: {collision.gameObject.name}");
    }
}
