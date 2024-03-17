using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOTrigger: MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Enemy") {			
			Global.GameOver = true;
        }
    }

}
