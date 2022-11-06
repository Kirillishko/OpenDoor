using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCamera : MonoBehaviour
{
    public GameObject Dooor;
    public GameObject Player;
    public float Speed;
    public TextMeshPro Code;
    private Vector3 _rot = new Vector3(0, 0, 0);
    private Door doorS;
    void Start()
    {
        doorS = Dooor.GetComponent<Door>();
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * Speed;
        float MouseY = Input.GetAxis("Mouse Y") * Speed;
        _rot.x = _rot.x - MouseY;
        _rot.y = _rot.y + MouseX;
        if (_rot.x > 90) _rot.x = 90;
        if (_rot.x < -90) _rot.x = -90;
        _rot.z = 0;
        transform.eulerAngles = _rot;
        Player.transform.eulerAngles = new Vector3(0, _rot.y, 0);
    }

    public void PressKey()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
        
        Physics.Raycast(ray, out hit);

        if (hit.collider != null)
        {
            if (Code.text.Length < 4)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (hit.collider.name == "Num " + i)
                    {
                        Code.text += i;
                        CheckCode();
                        return;
                    }
                }
            }
            if (hit.collider.name == "Backspace")
            {
                if (Code.text.Length != 0)
                {
                    string temp = Code.text.Remove(Code.text.Length - 1, 1);
                    Code.text = temp;
                    CheckCode();
                }
            }
        }
    }

    private void CheckCode()
    {
        if (Code.text == "2020")
        {
            doorS.IsOpened = true;
        }
        else doorS.IsOpened = false;
    }
}
