using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoladaFornadas : MonoBehaviour
{
    public Fornadas fornadasManager;

    public void RolagemFornadas()
    {
        fornadasManager.AdicionarFornada(); // Chama o método do Fornadas
    }
}