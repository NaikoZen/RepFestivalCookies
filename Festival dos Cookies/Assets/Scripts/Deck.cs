using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cardPrefabs; // Lista com todas as cartas possíveis
    public List<Card> deck; // O baralho embaralhado

    private void Start()
    {
        CreateDeck();
        ShuffleDeck();
    }

    private void CreateDeck()
    {
        deck = new List<Card>();
        foreach (Card card in cardPrefabs)
        {
            // Adicione várias cópias se necessário
            deck.Add(card);
        }
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public Card DrawCard()
    {
        if (deck.Count == 0) return null;

        Card drawnCard = deck[0];
        deck.RemoveAt(0);
        return drawnCard;
    }
}
