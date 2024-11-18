using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragEDrop : MonoBehaviour
{
    private Vector3 offset; // Armazena a diferença entre o objeto e a posição do mouse
    private Camera cam;     // Referência para a câmera principal

    private void Start()
    {
        cam = Camera.main; // Obtém a câmera principal
    }

    private void OnMouseDown()
    {
        // Calcula a diferença entre a posição do objeto e o mouse no mundo 3D
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        // Atualiza a posição do objeto para seguir o mouse enquanto o botão está pressionado
        transform.position = GetMouseWorldPos() + offset;
    }

    private Vector3 GetMouseWorldPos()
    {
        // Obtém a posição do mouse no espaço da tela e converte para espaço do mundo
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.WorldToScreenPoint(transform.position).z; // Define a profundidade do objeto
        return cam.ScreenToWorldPoint(mousePoint); // Retorna a posição no espaço do mundo
    }
}