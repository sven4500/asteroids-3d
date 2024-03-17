using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOTrigger: MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Enemy") {			
			TextMesh textMesh = _gameOverText.GetComponent<TextMesh>();
			textMesh.text = string.Format("Game over! Your score is {0}", UpdateScore.GetScore());
			
            _gameOverText.SetActive(true);
        }
    }

    public GameObject _gameOverText = null;

}
