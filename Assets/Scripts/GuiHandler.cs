using TMPro;
using UnityEngine;

public class GuiHandler : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private LevelHandler _levelHandler;

    void OnPointScoredHandler(int score) {
        _pointsText.SetText(score.ToString());
    }

    void Awake() {
        _levelHandler.OnPointScored += OnPointScoredHandler;
    }
}
