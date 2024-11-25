using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> cardsInHand = new List<Card>(); // Lista de cartas na mao
    public Transform handTransform; // Transform onde as cartas serao posicionadas na interface
    public float cardSpacing = 1.5f; // Espacamento entre as cartas
    public Vector3 baseCardRotation = new Vector3(0, 0, 10); // Rotacao base das cartas

    private void Start()
    {
        if (handTransform == null)
        {
            handTransform = this.transform; // Define o transform padrao como o do GameObject
        }
    }

    /// <summary>
    /// Adiciona uma carta a mao.
    /// </summary>
    public void AddCard(Card card)
    {
        if (card == null)
        {
            Debug.LogError("Tentando adicionar uma carta nula!");
            return;
        }

        cardsInHand.Add(card);
        card.transform.SetParent(handTransform); // Coloca a carta na mao visualmente
        card.transform.localScale = Vector3.one; // Ajusta o tamanho para evitar inconsistencias
        OrganizeHand(); // Reorganiza as cartas na mao
    }

    /// <summary>
    /// Remove uma carta especifica da mao.
    /// </summary>
    public void RemoveCard(Card card)
    {
        if (card == null)
        {
            Debug.LogError("Tentando remover uma carta nula!");
            return;
        }

        if (cardsInHand.Contains(card))
        {
            cardsInHand.Remove(card);
            OrganizeHand(); // Reorganiza a mao apos a remocao
        }
        else
        {
            Debug.LogWarning($"Carta '{card.name}' nao encontrada na mao!");
        }
    }

    /// <summary>
    /// Organiza as cartas na mao visualmente.
    /// </summary>
    private void OrganizeHand()
    {
        if (cardsInHand.Count == 0)
        {
            Debug.Log("Nenhuma carta na mao para organizar.");
            return;
        }

        float totalWidth = (cardsInHand.Count - 1) * cardSpacing;
        float startX = -totalWidth / 2;

        for (int i = 0; i < cardsInHand.Count; i++)
        {
            Vector3 cardPosition = new Vector3(startX + i * cardSpacing, 0, 0);
            cardsInHand[i].transform.localPosition = cardPosition;

            // Aplica uma rotacao base gradual (ex.: efeito em arco)
            Vector3 rotation = baseCardRotation * (i - cardsInHand.Count / 2f);
            cardsInHand[i].transform.localRotation = Quaternion.Euler(rotation);
        }
    }

    /// <summary>
    /// Obtem todas as cartas da mao (ex.: para jogadas ou descarte).
    /// </summary>
    public List<Card> GetCards()
    {
        return new List<Card>(cardsInHand); // Retorna uma copia da lista
    }

    /// <summary>
    /// Descarta uma carta da mao.
    /// </summary>
    public Card DiscardCard(int index)
    {
        if (index < 0 || index >= cardsInHand.Count)
        {
            Debug.LogError($"Indice invalido ({index}) para descarte de carta.");
            return null;
        }

        Card discardedCard = cardsInHand[index];
        RemoveCard(discardedCard); // Remove a carta da mao
        return discardedCard;
    }
}
