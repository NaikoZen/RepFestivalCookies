using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragEDrop : MonoBehaviour
{
    private Vector3 offset; // Armazena a diferen�a entre o objeto e a posi��o do mouse
    private Camera cam;     // Refer�ncia para a c�mera principal

    private void Start()
    {
        cam = Camera.main; // Obt�m a c�mera principal
    }

    private void OnMouseDown()
    {
        // Calcula a diferen�a entre a posi��o do objeto e o mouse no mundo 3D
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        // Atualiza a posi��o do objeto para seguir o mouse enquanto o bot�o est� pressionado
        transform.position = GetMouseWorldPos() + offset;
    }

    private Vector3 GetMouseWorldPos()
    {
        // Obt�m a posi��o do mouse no espa�o da tela e converte para espa�o do mundo
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.WorldToScreenPoint(transform.position).z; // Define a profundidade do objeto
        return cam.ScreenToWorldPoint(mousePoint); // Retorna a posi��o no espa�o do mundo
    }
}