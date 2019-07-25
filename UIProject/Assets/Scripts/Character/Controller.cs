using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Character chara;
    private void Start()
    {
        chara = GetComponent<Character>();
    }
    private void FixedUpdate()
    {
        chara.PlayerMove(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void Update()
    {
        chara.PlayerRotate(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        chara.PlayerAttack(Input.GetKeyDown(KeyCode.Space));
    }
}
