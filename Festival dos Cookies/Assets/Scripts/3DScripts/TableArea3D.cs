using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableArea3D : MonoBehaviour
{
    public GameManager3D gameManager;
    public bool Estanaareajogavel;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.CompareTag("Card"))
        {
            Estanaareajogavel = true;
            Debug.Log($"Carta {other.name} jogada na mesa!");
            gameManager.OnCardPlayed(other.gameObject); // Avisa o GameManager
        }
    }
}