using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
    public List<GameObject> hand; // Cartas na mão

    public GameObject PlayCard()
    {
        if (hand.Count == 0)
        {
            Debug.Log("IA não tem cartas para jogar!");
            return null;
        }

        // Escolhe uma carta aleatoriamente (adicione lógica para estratégias)
        GameObject chosenCard = hand[Random.Range(0, hand.Count)];
        hand.Remove(chosenCard);

        return chosenCard;
    }
}