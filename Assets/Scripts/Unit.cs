using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private CharacterController player;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float distanceOffset;
    bool moveStop;

    private Vector3 targetPosition;

    private void Start()
    {
        moveStop = true;
    }
    /*private void OnMouseOver()
    {
        Debug.Log($"OnMouseOver");
    }*/

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && moveStop)
        {
            moveStop = false;
            Move(MouseWorld.GetPosition());
        }

        if (Vector3.Distance(transform.position, targetPosition) > distanceOffset)
        {
            var moveDirection = (targetPosition - transform.position).normalized;

            //transform.position += moveDirection * moveSpeed * Time.deltaTime;
            player.Move(moveDirection * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveStop = true;
            player.Move(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveStop = true;
            player.Move(-Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveStop = true;
            player.Move(-Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveStop = true;
            player.Move(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }
    private void OnMouseDrag()
    {
        //transform.position = MouseWorld.GetPosition();  
        Move(MouseWorld.GetPosition());
    }

    private void Move(Vector3 targetPos)
    {
        this.targetPosition = targetPos;
    }

    //private void Movement()
    //{
    //    moveStop = true;
    //    //Vector3 movePosition = this.targetPosition;

    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        player.Move(Vector3.forward * Time.deltaTime * moveSpeed);
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        player.Move(-Vector3.forward * Time.deltaTime * moveSpeed);
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        player.Move(-Vector3.right * Time.deltaTime * moveSpeed);
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        //movePosition.x += moveSpeed;
    //        player.Move(Vector3.right * Time.deltaTime * moveSpeed);
    //    }

    //    //Move(movePosition);
    //}
}
