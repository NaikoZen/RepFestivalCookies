using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Deck deckManager;
    public Player[] players; // Array de jogadores
    public int currentPlayerIndex;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        foreach (Player player in players)
        {
            for (int i = 0; i < 7; i++)
            {
                player.DrawCard(deckManager.DrawCard());
            }
        }
        currentPlayerIndex = 0;
    }

    public void NextTurn()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        Debug.Log($"Turno do jogador {currentPlayerIndex + 1}");
    }
}
