using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpdateScore: MonoBehaviour {

    private void Awake() {
        _doc = GetComponent<UIDocument>();
        setScore(0);
    }

    public static void setScore(System.UInt32 score) {
        if(_doc != null) {
			Label scoreLabel = _doc.rootVisualElement.Q<Label>("ScoreLabel");
            scoreLabel.text = score.ToString("D8");
        }
    }

    private static UIDocument _doc = null;

}
