using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpdateScore: MonoBehaviour {

    private void Awake() {
        _doc = GetComponent<UIDocument>();
        UpdateScoreLabel();
    }
	
	void Update() {
		_time += Time.deltaTime;
		
		if (_time > 1.0f) {
			_score++;
			UpdateScoreLabel();
			
			_time = 0.0f;
		}
	}
	
	public static int GetScore() {
		return _score;
	}
	
	public static void IncrementScore() {
		_score++;
		UpdateScoreLabel();
	}

    private static void UpdateScoreLabel() {
        if(_doc != null) {
			Label scoreLabel = _doc.rootVisualElement.Q<Label>("ScoreLabel");
            scoreLabel.text = _score.ToString("D8");
        }
    }

    private static UIDocument _doc = null;
	private static int _score = 0;
	private float _time = 0.0f;

}
