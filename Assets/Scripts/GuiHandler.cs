using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuiHandler : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private LevelHandler _levelHandler;
    [SerializeField] private RawImage _gameOverImage;


    void OnPointScoredHandler(int score) {
        _pointsText.SetText(score.ToString());
    }

    void OnGameOverHandler() {
        print("Tweening image alpha");
        _gameOverImage.CrossFadeAlpha(1, 1, false);
    }

    void Awake() {
        _gameOverImage.canvasRenderer.SetAlpha(0);

        _levelHandler.OnPointScored += OnPointScoredHandler;
        _levelHandler.OnGameOver += OnGameOverHandler;
    }

}
