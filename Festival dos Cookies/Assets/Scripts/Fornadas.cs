using TMPro;
using UnityEngine;
using UnityEngine.UI; // Necessário para trabalhar com UI

public class Fornadas : MonoBehaviour
{
    public TMP_Text contadorTexto; // UI para exibir o número de cookies
    private int fornadasObtidas = 0; // Contador de fornadas
    private int contagemCookies = 0; // Contagem de cookies

    // Atualiza o texto na tela
    void AtualizarTexto()
    {
        contagemCookies = fornadasObtidas; // Sincroniza os valores
        contadorTexto.text = contagemCookies.ToString();
    }

    // Método chamado pelo botão para adicionar fornadas aleatórias
    public void AdicionarFornada()
    {
        // Adiciona um valor aleatório ao fornadasObtidas
        int[] valores = { 10, 20, 30, 40, 50, 60 };
        int valorAleatorio = valores[Random.Range(0, valores.Length)];
        fornadasObtidas += valorAleatorio; // Incrementa o contador
        AtualizarTexto(); // Atualiza a UI
    }

    void Start()
    {
        contagemCookies = 0;
        AtualizarTexto(); // Configura o texto inicial
    }
}