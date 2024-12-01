using TMPro;
using UnityEngine;
using UnityEngine.UI; // Necess�rio para trabalhar com UI

public class Fornadas : MonoBehaviour
{
    public TMP_Text contadorTexto; // UI para exibir o n�mero de cookies
    private int fornadasObtidas = 0; // Contador de fornadas
    private int contagemCookies = 0; // Contagem de cookies

    // Atualiza o texto na tela
    void AtualizarTexto()
    {
        contagemCookies = fornadasObtidas; // Sincroniza os valores
        contadorTexto.text = contagemCookies.ToString();
    }

    // M�todo chamado pelo bot�o para adicionar fornadas aleat�rias
    public void AdicionarFornada()
    {
        // Adiciona um valor aleat�rio ao fornadasObtidas
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