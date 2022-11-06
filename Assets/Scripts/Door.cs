using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Player;
    public bool IsOpened = false;

    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpened && Vector3.Distance(transform.position, Player.gameObject.transform.position) <= 8)
        {
            _anim.SetBool("IsOpened", true);
            _anim.SetFloat("Speed", 1.0f);
        }
        else
        {
            _anim.SetBool("IsOpened", false);
            _anim.SetFloat("Speed", -1.0f);
        }
    }
}
