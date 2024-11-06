using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card : ScriptableObject
{
    // Define os tipos de carta
    public enum CardType
    {
        Ataque,
        Defesa,
        DefesaPassiva,
        SemDefesa,
        Beneficio
    }

    public string cartaNome;
    public string cartaDescricao;
    public Sprite art;
    public int cartaAtaque;
    public int cartaCusto;
    public CardType cartaTipo;

    // Construtor que aceita todos os parâmetros, incluindo o tipo de carta
    // p.s botei as variáveis em pt pq em inglês fica mt trampo
    public Card(string nome, string descricao, int ataque, int custo, CardType tipo)
    {
        cartaNome = nome;
        cartaDescricao = descricao;
        cartaAtaque = ataque;
        cartaCusto = custo;
        cartaTipo = tipo;
    }
}