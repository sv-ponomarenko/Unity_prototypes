using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>	
///	Предотвращает выход игрового объекта за границы экрана	
/// Работает только с ортографической камерой Майн камера 000
/// </summary>

public class BoundsCheck : MonoBehaviour {   
	[Header("Set in Inspector")]
	public float	radius = 1f;
	public bool keepOnScreen = true; //a

	[Header("Set Dynamically")]
	public bool isOnScreen = true; //b
	public float	camWidth;
	public float	camHeight;

	[HideInInspector]
	public bool	offRight, offLeft, offUp, offDown;

	void Awake() {
		camHeight = Camera.main.orthographicSize;	
		camWidth = camHeight * Camera.main.aspect;	
	}

	void LateUpdate() {
		Vector3 pos = transform.position;	//c
		isOnScreen = true;	//d
		offRight = offLeft = offUp = offDown = false;

		if (pos.x > camWidth - radius) {
			pos.x = camWidth - radius;
			offRight = true; //e
		}
		if (pos.x < -camWidth + radius) {
			pos.x = -camWidth + radius;
			offLeft = true;
		}

		if (pos.y > camHeight - radius) {
			pos.y = camHeight - radius;
			offUp = true;
		}
		if (pos.y < -camHeight + radius) {
			pos.y = -camHeight + radius;
			offDown = true; //e
		}

		isOnScreen = !(offRight || offLeft || offUp || offDown);
		if (keepOnScreen && !isOnScreen) { //f
		transform.position = pos;	//g
		isOnScreen = true;
			offRight = offLeft = offUp = offDown = false;
	}
	}

	void OnDrawGizmos() {	
		if (!Application.isPlaying) return;
		Vector3 boundSize = new Vector3 (camWidth * 2, camHeight * 2, 0.1f);
		Gizmos.DrawWireCube (Vector3.zero, boundSize);
	}


}
