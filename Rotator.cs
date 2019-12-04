using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	void Update () {
		//Fija la camara a una posicion que sigue al jugador.
		transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
	}
}
