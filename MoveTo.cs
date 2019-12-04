﻿using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour{
public Transform goal;
public float proximidad;
NavMeshAgent agent;
Animator animacion;

void Start(){
    //Cargas el mapa del agente y la animacion.
    agent=GetComponent<NavMeshAgent>();
    animacion = goal.GetComponent<Animator>();
}
void Update(){
    agent.SetDestination (goal.position);
    //busca la posicion a la que esta el agente del jugador y segun la que sea estable una animacion u otra ademas de cambiar la variable de dicha animacion.

            if (!agent.pathPending && agent.remainingDistance < proximidad)
        {
            Debug.Log("Peligro");
            // cambiamos a true la variable del animator
            animacion.SetBool("EstarEnPeligro", true);
        }
        else
        {
            Debug.Log("Tranqui");
            // cambiamos a false la variable del animator
            animacion.SetBool("EstarEnPeligro", false);
        }
}
}