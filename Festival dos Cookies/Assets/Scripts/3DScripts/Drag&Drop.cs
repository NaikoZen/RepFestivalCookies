using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragEDrop : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    Collider2D collider2D;
    public GameManager3D gameManager;

    public TableArea3D tableArea3D;
    private bool isDragging = false;
    private float zPlane; // Plano onde as cartas serão arrastadas
    public Transform dropArea; // Zona onde a carta pode ser solta
    public string destinationTag = "DropArea"; // Procura pelo objeto com essa tag

    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
    }
    private void Start()

    {
        /*
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
        */

        dropArea = GameObject.Find("DropArea").transform; // Localiza o objeto de "drop"
    }

    private void OnMouseDown()
    {
        /*
        isDragging = true;

        // Calcula o plano de movimento com base na posição inicial
        zPlane = transform.position.z;

        // Calcula o deslocamento entre o clique e a posição da carta
        Vector3 mousePos = GetMouseWorldPosition();
        offset = transform.position - mousePos;
        */

        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        /*
        bool estaNaArea = tableArea3D.Estanaareajogavel;
        if (isDragging)
        {
            Vector3 mousePos = GetMouseWorldPosition();
            Vector3 newPos = new Vector3(mousePos.x + offset.x, transform.position.y, mousePos.z + offset.z);
            transform.position = newPos;
        }
        */
        transform.position = GetMouseWorldPosition() + offset;
    }

    private void OnMouseUp()
    {
        /*
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
        */

        collider2D.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = GetMouseWorldPosition() - Camera.main.transform.position;

        RaycastHit2D hitInfo;
        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
            }
        }
        collider2D.enabled = true;
    }

    private Vector3 GetMouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
        /*
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, zPlane));
        plane.Raycast(ray, out float distance);
        return ray.GetPoint(distance);
        */
    }

    /*
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

    private bool IsInsideDropArea()
    {
        // Verifica se o objeto está dentro da área de drop
        Collider2D dropAreaCollider = dropArea.GetComponent<Collider2D>();
        if (dropAreaCollider != null && dropAreaCollider.bounds.Contains(transform.position))
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("A carta colidiu com algo!");
    }
    */
}