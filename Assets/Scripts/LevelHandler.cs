using System;
using UnityEngine;

public class LevelHandler : MonoBehaviour {

    private int _score = 0;

    [SerializeField] private BirdController _birdController;

    [SerializeField] private AudioSource _soundEffectsSource;
    [SerializeField] private AudioClip _soundPoint;

    public event Action<int> OnPointScored;

    void OnPointScoredHandler() {
        _score += 1;
        _soundEffectsSource.PlayOneShot(_soundPoint);
        print($"Scored point! Total points {_score}");
        OnPointScored.Invoke(_score);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _birdController.OnPointScored += OnPointScoredHandler;
    }

    // Update is called once per frame
    void Update() {

    }
}
