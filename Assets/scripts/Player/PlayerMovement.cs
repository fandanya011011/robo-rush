using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float speedSide;
    [SerializeField] private float gravity;
    [SerializeField] private int lineToMove = 1;
    [SerializeField] private float lineDistance;
        private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    private void Update()
    {
        Vector3 speed = new Vector3(0, gravity, speedMove);
        controller.Move(speed * Time.deltaTime);
        Vector3 targetPosition = new Vector3();
        targetPosition.z = transform.position.z;
        targetPosition.y = transform.position.y;
        targetPosition.x = 0;

        if (lineToMove == 0)
        {
            targetPosition.x = -lineDistance;
        }
        else if (lineToMove == 2)
        {
            targetPosition.x = lineDistance;
        }

        transform.position = targetPosition;
    }

    public void MovementSide(bool isRight)
    {
            if (isRight && lineToMove < 2)
        {
                lineToMove += 1;
        }
        if (!isRight && lineToMove > 0)
        {
            lineToMove -= 1;
        }
    }
}
