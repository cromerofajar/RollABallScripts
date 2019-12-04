using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //Velocidad del jugador.
    public float speed;
    //Contador de puntuacion texto.
    public Text countText;
    //Texto de victoria/Derrota.
    public Text winText;
    //Cuerpo solido sin asignar.
    private Rigidbody rb;
    //Contador numero
    private int count;

    void Start ()
    {
        //asignacion del cuerpo rigido.
        rb = GetComponent<Rigidbody>();
        //contador a 0.
        count = 0;
        //Establecer el texto del contador de puntuaciones.
        SetCountText ();
        //Deja el campo de texto de la victoria vacio.
        winText.text = "";
        

    }

    void FixedUpdate ()
    {
        //Asignacion de las flechas y las teclas wasd para movimiento en los ejes.
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        //Vectores de movimiento en 3d
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        //generacion del movimiento
        rb.AddForce (movement * speed);
        //En caso de ganar te teletransporta al centro del mapa y te deja fijo a el.
        if (count >= 31)
        {
            rb.transform.position=Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        //Cuando pasas por un pickup lo borra y te suma uno al contador ademas de actualizar el texto.
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
        //Si el enemigo choca contra ti una vez tienes todos los pick ups es eliminado.
        if (other.gameObject.CompareTag("Enemy")&& count>=31){
            other.gameObject.SetActive(false);
        }
        //En caso de no tener todos los coleccionables te elimina a ti y pone que has perdido
        else if(other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            winText.text="Pierdes";
        }
        //Si caes al agua y no tienes todos los pickups pierdes.
        else if(other.gameObject.CompareTag("Water")&&count<31){
            gameObject.SetActive(false);
            winText.text="Pierdes";
        }
        
    }

    void SetCountText ()
    {
        //Escribe en el contador en caso de llegar a 31 pone en el texto de victoria/derrota Has ganado.
        countText.text = "Count: " + count.ToString ();
        if (count >= 31)
        {
            winText.text = "Has ganado";  
        }
        
    }
}