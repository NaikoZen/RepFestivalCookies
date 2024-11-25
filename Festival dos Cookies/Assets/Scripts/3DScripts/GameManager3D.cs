using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3D : MonoBehaviour
{
    public Player3D player;
    public Player3D aiPlayer;

    private bool isPlayerTurn = true;

    public void OnCardPlayed(GameObject card)
    {
        if (isPlayerTurn)
        {
            Debug.Log("Carta do jogador jogada!");
            Destroy(card); // Opcional: Remove a carta

            EndPlayerTurn();
        }
    }

    private void EndPlayerTurn()
    {
        isPlayerTurn = false;
        StartAITurn();
    }

    private void StartAITurn()
    {
        Debug.Log("Turno da IA!");
        GameObject chosenCard = aiPlayer.PlayCard(); // IA joga uma carta
        Debug.Log($"IA jogou {chosenCard.name}!");

        Destroy(chosenCard); // Remove a carta da IA (simulação)
        EndAITurn();
    }

    private void EndAITurn()
    {
        isPlayerTurn = true;
        Debug.Log("Seu turno!");
    }
}