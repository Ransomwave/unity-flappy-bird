using System;
using UnityEngine;

public class SoundHandler : MonoBehaviour {


    [SerializeField] private AudioClip _soundPoint;
    [SerializeField] private AudioClip _soundHit;

    [SerializeField] private LevelHandler _levelHandler;
    [SerializeField] private BirdController _birdController;

    private AudioSource _soundEffectsSource;


    private void OnPipeTouchedHandler() {
        _soundEffectsSource.PlayOneShot(_soundHit);
    }

    private void OnPointScoredHandler() {
        _soundEffectsSource.PlayOneShot(_soundPoint);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake() {
        _soundEffectsSource = GetComponent<AudioSource>();

        _birdController.OnPointScored += OnPointScoredHandler;
        _birdController.OnPipeTouched += OnPipeTouchedHandler;
    }
}
