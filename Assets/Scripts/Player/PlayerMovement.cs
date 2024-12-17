using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float MAX_SPEED = 30f;
    const float MAX_ROTATION_SPEED = 300f;
    [SerializeField] float speedDecay = 1f;
    [SerializeField] float speedAccel = 5f;
    [SerializeField] float rotationAccel = 5f;
    [SerializeField] float rotationDecay = 1f;
    float moveSpeed = 0f;
    float rotationSpeed = 0f;
    private float isMoving = 0f;
    private float isRotating = 0f;

    void Update()
    {
        isMoving = Input.GetAxis("Vertical");
        isRotating = Input.GetAxis("Horizontal");

        HandleMoveSpeed();
        HandleRotationSpeed();
        MovePlayer();
        RotatePlayer();
    }

    private void HandleRotationSpeed()
    {
        if (isRotating != 0f) {
            rotationSpeed += math.sign(isRotating) * rotationAccel * Time.deltaTime;
        } else {
            rotationSpeed -= rotationDecay * Time.deltaTime;
            rotationSpeed = math.max(rotationSpeed, 0f);
        }
        if (rotationSpeed > MAX_ROTATION_SPEED) {
            rotationSpeed = MAX_ROTATION_SPEED;
        }
    }

    private void HandleMoveSpeed()
    {
        if (isMoving > 0f) {
            moveSpeed += speedAccel * Time.deltaTime;
        } else {
            moveSpeed -= speedDecay * Time.deltaTime;
            moveSpeed = math.max(moveSpeed, 0f);
        }
        if (moveSpeed > MAX_SPEED) {
            moveSpeed = MAX_SPEED;
        }
    }

    void MovePlayer() {
        if (moveSpeed != 0f)
            transform.Translate(moveSpeed * Vector3.up);
        
    }
    
    void RotatePlayer() {
        if (rotationSpeed != 0f)
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
