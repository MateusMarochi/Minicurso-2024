using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentar : MonoBehaviour
{
    // Controlador do personagem
    private CharacterController controller;
    // Transform da câmera
    private Transform camera;

    void Start()
    {
        // Obtém o CharacterController
        controller = GetComponent<CharacterController>();
        // Obtém a câmera principal
        camera = Camera.main.transform;
    }

    // Atualizado a cada frame
    void Update()
    {
        // Movimento horizontal
        float horizontal = Input.GetAxis("Horizontal");
        // Movimento vertical
        float vertical = Input.GetAxis("Vertical");

        // Vetor de movimento
        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        // Ajusta para a direção da câmera
        movimento = camera.TransformDirection(movimento);

        // Move o personagem
        controller.Move(movimento * Time.deltaTime * 5);
        // Aplica gravidade
        controller.Move(new Vector3(0, -9.8f, 0) * Time.deltaTime);

        // Rotaciona o personagem na direção do movimento
        if (movimento != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movimento);
        }
    }
}
