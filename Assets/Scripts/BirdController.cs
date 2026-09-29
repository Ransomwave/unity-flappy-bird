using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour {
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private InputActionReference _jumpActionReference;

    [SerializeField] private LevelHandler _levelHandler;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private bool _isActive = false;

    public event Action OnPointScored;
    public event Action OnPipeTouched;
    public event Action OnJump;

    // My methods
    void Jump(InputAction.CallbackContext context) {
        if (!_isActive) return;

        OnJump.Invoke();
        _rigidbody2D.linearVelocity = Vector2.zero; // Reset the velocity before applying the jump force
        _rigidbody2D.AddForceY(_jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Resets the bird position, rotation, and physics.
    /// </summary>
    public void ResetBird() {
        _collider2D.enabled = true;
        _rigidbody2D.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.simulated = false; // Stay still until the player presses the jump button
        _isActive = false;
    }

    /// <summary>
    /// Resumes bird control and physics.
    /// </summary>
    public void ResumeControl() {
        _isActive = true;
        _rigidbody2D.simulated = true;
    }


    // Unity methods
    void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D.simulated = false; // initialize still until game start
    }

    void OnEnable() {
        _jumpActionReference.action.performed += Jump;
    }

    void OnDisable() {
        _jumpActionReference.action.performed -= Jump;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (!_isActive) return;
        if (collision.gameObject.tag == "kill") {
            _isActive = false;
            OnPipeTouched.Invoke();
            _collider2D.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (!_isActive) return;
        if (collision.gameObject.name == "AddPointTrigger") {
            OnPointScored.Invoke();
        }
    }
}
