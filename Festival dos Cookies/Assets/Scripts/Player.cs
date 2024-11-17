using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Card> hand; // Cartas na mão do jogador
    public bool isAI; // Identifica se é um jogador ou IA

    public void DrawCard(Card card)
    {
        hand.Add(card);
    }

    public void PlayCard(Card card, Deck deck)
    {
        if (CanPlayCard(card))
        {
            hand.Remove(card);
            // Enviar para a pilha de descarte
            Debug.Log($"Jogador jogou {card.color} {card.value}");
        }
        else
        {
            Debug.Log("Jogada inválida!");
        }
    }

    private bool CanPlayCard(Card card)
    {
        // Regras simples para determinar se a carta pode ser jogada
        return true; // Ajuste de acordo com suas regras
    }
}
