using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Objeto : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    [SerializeField] private float CantidadPuntos;
    [SerializeField] private ContadorJuego contadorJuego;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contadorJuego.SumarPuntos(CantidadPuntos);
            Debug.Log("Objeto recogido!");
            Destroy(gameObject); 
        }
    }
}
