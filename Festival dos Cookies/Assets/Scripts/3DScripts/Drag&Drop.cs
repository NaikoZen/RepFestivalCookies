using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragEDrop : MonoBehaviour
{
    public TableArea3D tableArea3D;
    public GameManager3D gameManager;
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;
    private float zPlane; // Plano onde as cartas serão arrastadas



    private void Start()

    {
        if (tableArea3D == null)
        { 
            tableArea3D = GameObject.FindWithTag("TableArea").GetComponent<TableArea3D>();
        }
        if (gameManager == null)
        { 
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager3D>();
        }
    tableArea3D = GetComponent<TableArea3D>();
        gameManager = GetComponent<GameManager3D>();
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        isDragging = true;

        // Calcula o plano de movimento com base na posição inicial
        zPlane = transform.position.z;

        // Calcula o deslocamento entre o clique e a posição da carta
        Vector3 mousePos = GetMouseWorldPosition();
        offset = transform.position - mousePos;
    }

    private void OnMouseDrag()
    {
        bool estaNaArea = tableArea3D.Estanaareajogavel;
        if (isDragging)
        {
            Vector3 mousePos = GetMouseWorldPosition();
            Vector3 newPos = new Vector3(mousePos.x + offset.x, transform.position.y, mousePos.z + offset.z);
            transform.position = newPos;
        }
    }

    private void OnMouseUp()
    {
        bool estaNaArea = tableArea3D.Estanaareajogavel;

        isDragging = false;

        // Opcional: Valida se a carta está em uma área válida (por exemplo, na mesa)
        if (IsInPlayArea())
        {
            Debug.Log("Carta jogada!");
        }
        else
        {
            Debug.Log("Área inválida. Retornando à posição inicial.");
            // Volta para a posição original
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, zPlane));
        plane.Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }

    private bool IsInPlayArea()
    {
        bool estaNaArea = tableArea3D.Estanaareajogavel;

        if (estaNaArea == true)
        {
            // Adicione lógica para verificar se a carta foi arrastada para uma área válida
            return true;
        }
        else
        {
            // Adicione lógica para verificar se a carta foi arrastada para uma área válida
            return false;
        }

       
       
    }
}