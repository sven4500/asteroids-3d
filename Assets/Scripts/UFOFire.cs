using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFire: MonoBehaviour {

	void Update() {
        _time += Time.deltaTime;
		if(_time > _fireRate && Input.GetKeyDown(KeyCode.Space) == true) {
			Quaternion rot = Quaternion.identity;
			rot.eulerAngles = new Vector3(90, 0, 0);
			
            Vector3 pos = transform.position;
			
            Instantiate(Resources.Load("LaserCharge"), pos, rot);
            _time = 0.0F;
        }
	}

    private System.Single _time = 0.0F;
    public System.Single _fireRate = 1.0F;

}
