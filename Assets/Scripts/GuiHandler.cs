using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GuiHandler : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private LevelHandler _levelHandler;
    [SerializeField] private RawImage _gameOverImage;
    [SerializeField] private RawImage _startGameImage;


    void OnPointScoredHandler(int score) {
        _pointsText.SetText(score.ToString());
    }

    public void ShowGameOver() {
        _gameOverImage.CrossFadeAlpha(1, 1, false);
    }

    public void ShowGameMenu() {
        if (_gameOverImage.canvasRenderer.GetAlpha() > 0) {
            _gameOverImage.CrossFadeAlpha(0, 1, false);

        }
        _pointsText.SetText("0");
        _pointsText.CrossFadeAlpha(0, 1, false);
        _startGameImage.CrossFadeAlpha(1, 1, false);
    }

    public void StartGame() {
        _startGameImage.CrossFadeAlpha(0, 1, false);
        _pointsText.CrossFadeAlpha(1, 1, false);
    }

    void Awake() {
        _startGameImage.canvasRenderer.SetAlpha(0);
        _gameOverImage.canvasRenderer.SetAlpha(0);

        _levelHandler.OnPointScored += OnPointScoredHandler;
    }

}
