using System;
using UnityEngine;

public class LevelHandler : MonoBehaviour {

    private int _score = 0;

    [SerializeField] private BirdController _birdController;

    void OnPointScoredHandler() {
        _score += 1;
        print($"Scored point! Total points {_score}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _birdController.OnPointScored += OnPointScoredHandler;
    }

    // Update is called once per frame
    void Update() {

    }
}
