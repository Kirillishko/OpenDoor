using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public float SpreadSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) Movement(1);
        if (Input.GetKey(KeyCode.S)) Movement(-1);
        if (Input.GetKey(KeyCode.D)) Spread(1);
        if (Input.GetKey(KeyCode.A)) Spread(-1);
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponentInChildren<PlayerCamera>().PressKey();
        }
    }

    private void Movement(int direction)
    {
        transform.Translate(transform.forward * MovementSpeed * Time.deltaTime * direction, Space.World);
    }
    private void Spread(int direction)
    {
        transform.Translate(transform.right * SpreadSpeed * Time.deltaTime * direction, Space.World);
    }
}
