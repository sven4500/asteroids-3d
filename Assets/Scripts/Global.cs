using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Global: MonoBehaviour {

    void Awake() {
        _timeout = _respawnTime;
		UpdateScoreLabel();
    }

	void LateUpdate() {
        if(Input.GetKeyDown(KeyCode.Escape) == true)
            Application.Quit();

        _timeout += Time.deltaTime;

        if(_timeout > _respawnTime) {

            Vector3 pos = new Vector3(
                Random.Range(-_width, _width),
                Random.Range(-_height, _height),
                _distance);

            GameObject obj = (GameObject)Instantiate(Resources.Load("Rock" + Random.Range(1, 4)), pos, Quaternion.identity);

            // Give asteroid a random velocity
            RockMovement rock = obj.GetComponent<RockMovement>();
            rock._speed = Random.Range(_speedMin, _speedMax);
            rock._rotationSpeed = Random.Range(_rotationSpeedMin, _rotationSpeedMax);

            _timeout = 0.0F;
        }
	}
		
	void Update() {
		_scoreTimeout += Time.deltaTime;
		
		if (_scoreTimeout > 1.0f) {
			Score++;
			UpdateScoreLabel();
			
			_scoreTimeout = 0.0f;
		}
		
		if (!_gameOverText.activeSelf && GameOver) {
			TextMesh textMesh = _gameOverText.GetComponent<TextMesh>();
			textMesh.text = string.Format("Game over! Your score is {0}", Global.Score);
			
			_gameOverText.SetActive(true);
		}
	}
	
	private void UpdateScoreLabel() {
        if(_UIDocument != null) {
			Label scoreLabel = _UIDocument.rootVisualElement.Q<Label>("ScoreLabel");
            scoreLabel.text = Score.ToString("D8");
        }
    }
		
	// Auto Score property
	public static int Score {
		get; set;
	}
	
	// You can set game over value only to true and only once
	private static bool _gameOver = false;
	public static bool GameOver {
		get { return _gameOver; }
		set { if (!_gameOver && value) _gameOver = value; }
	}
	
    public UIDocument _UIDocument = null;
	public GameObject _gameOverText = null;
	
    public System.Single _respawnTime = 1.0F;
    public System.Single _distance = 50.0F;

    public System.Single _speedMin = 1.0F;
    public System.Single _speedMax = 10.0F;

    public System.Single _rotationSpeedMin = 1.0F;
    public System.Single _rotationSpeedMax = 10.0F;

    public System.Single _width = 10.0F;
    public System.Single _height = 10.0F;

    private float _timeout = 0.0F;
	private float _scoreTimeout = 0.0f;
	
}
