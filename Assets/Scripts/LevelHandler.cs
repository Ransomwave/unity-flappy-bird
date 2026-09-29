using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelHandler : MonoBehaviour {

    private int _score = 0;

    [SerializeField] private BirdController _birdController;
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private GuiHandler _guiHandler;


    // controls
    [SerializeField] private InputActionReference _jumpActionReference; // used to continue

    public event Action<int> OnPointScored;

    /// <summary>
    /// Starts the game by resetting the score, the bird controller and pipe spawner.
    /// </summary>
    void StartGame() {
        _score = 0;
        _guiHandler.StartGame();
        _birdController.ResetBird();
        _birdController.ResumeControl();
        _pipeSpawner.Resume();
    }

    IEnumerator StartGameRoutine() {
        _guiHandler.ShowGameMenu();
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => _jumpActionReference.action.WasPressedThisFrame());
        StartGame();
    }

    IEnumerator GameOverRoutine() {
        _guiHandler.ShowGameOver();
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => _jumpActionReference.action.WasPressedThisFrame());
        yield return StartGameRoutine();
    }

    void OnPointScoredHandler() {
        _score += 1;
        OnPointScored.Invoke(_score);
    }

    void OnPipeTouchedHandler() {
        print("DEAD!!!");
        _pipeSpawner.Stop();

        StartCoroutine(GameOverRoutine());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _birdController.OnPointScored += OnPointScoredHandler;
        _birdController.OnPipeTouched += OnPipeTouchedHandler;

        StartCoroutine(StartGameRoutine());
    }
}
