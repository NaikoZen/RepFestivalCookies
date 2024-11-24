using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
    public List<GameObject> hand; // Cartas na m�o

    public GameObject PlayCard()
    {
        if (hand.Count == 0)
        {
            Debug.Log("IA n�o tem cartas para jogar!");
            return null;
        }

        // Escolhe uma carta aleatoriamente (adicione l�gica para estrat�gias)
        GameObject chosenCard = hand[Random.Range(0, hand.Count)];
        hand.Remove(chosenCard);

        return chosenCard;
    }
}