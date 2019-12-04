using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start ()
    {
        //La camara se fija al jugador.
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate ()
    {
        //La camara va siguiendo al jugador sin perder su posicion.
        transform.position = player.transform.position + offset;
    }
}
