using System;
using UnityEngine;

public class LevelHandler : MonoBehaviour {

    private int _score = 0;

    [SerializeField] private BirdController _birdController;
    [SerializeField] private PipeSpawner _pipeSpawner;

    [SerializeField] private AudioSource _soundEffectsSource;
    [SerializeField] private AudioClip _soundPoint;

    public event Action<int> OnPointScored;
    public event Action OnGameOver;

    void OnPointScoredHandler() {
        _score += 1;
        _soundEffectsSource.PlayOneShot(_soundPoint);
        OnPointScored.Invoke(_score);
    }

    void OnPipeTouchedHandler() {
        print("DEAD!!!");
        _pipeSpawner.Stop();
        OnGameOver.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _birdController.OnPointScored += OnPointScoredHandler;
        _birdController.OnPipeTouched += OnPipeTouchedHandler;
    }

    // Update is called once per frame
    void Update() {

    }
}
