using System;
using UnityEngine;

public class SoundHandler : MonoBehaviour {


    [SerializeField] private AudioClip _soundPoint;
    [SerializeField] private AudioClip _soundHit;
    [SerializeField] private AudioClip _soundWing;

    [SerializeField] private LevelHandler _levelHandler;
    [SerializeField] private BirdController _birdController;

    private AudioSource _soundEffectsSource;


    private void OnPipeTouchedHandler() {
        _soundEffectsSource.PlayOneShot(_soundHit);
    }

    private void OnPointScoredHandler() {
        _soundEffectsSource.PlayOneShot(_soundPoint);
    }

    private void OnJumpHandler() {
        _soundEffectsSource.PlayOneShot(_soundWing);
    }


    void Awake() {
        _soundEffectsSource = GetComponent<AudioSource>();

        _birdController.OnPointScored += OnPointScoredHandler;
        _birdController.OnPipeTouched += OnPipeTouchedHandler;
        _birdController.OnJump += OnJumpHandler;
    }
}
