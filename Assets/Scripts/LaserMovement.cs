using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement: MonoBehaviour {

    void Awake() {
        _rb = GetComponent<Rigidbody>();
		_speed = Random.Range(_speedMin, _speedMax);
		
		Vector3 scale = transform.localScale;
		scale.y *= (_speed / (_speedMax - _speedMin));
		
		transform.localScale = scale;
    }

	void Update() {
        if(_rb != null) {
            Vector3 pos = _rb.position;
            pos.z += _speed * Time.deltaTime;
			
            if(pos.z > _distance) {
                // Убиваем себя так как мы вышли за допустимую границу.
                // Здесь важно уничтожить не себя (this), а именно
                // игровой объект связанный с this.
                GameObject.Destroy(gameObject);
                return;
            }
			
            _rb.MovePosition(pos);
        }
	}

    private Rigidbody _rb = null;
	private float _speed = 1.0f;

    public float _distance = 1.0F;
    public float _speedMin = 1.0F;
	public float _speedMax = 1.0F;

}
