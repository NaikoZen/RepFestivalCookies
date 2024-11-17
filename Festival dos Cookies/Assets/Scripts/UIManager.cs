using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform handUI; // Área para mostrar as cartas na mão do jogador
    public GameObject cardUIPrefab;

    public void UpdateHandUI(Player player)
    {
        foreach (Transform child in handUI)
        {
            Destroy(child.gameObject);
        }

        foreach (Card card in player.hand)
        {
            GameObject cardUI = Instantiate(cardUIPrefab, handUI);
            cardUI.GetComponent<Image>().sprite = card.sprite;

            // Adicione funcionalidade de clique
            cardUI.GetComponent<Button>().onClick.AddListener(() =>
            {
                player.PlayCard(card, FindObjectOfType<Deck>());
            });
        }
    }
}
