using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// 플레이어 캐릭터의 이동 기능 스크립트
public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("이동 속도")] private float moveSpeed = 5f;
    // 플레이어 이동 방향
    private Vector2 moveDir = Vector2.zero;

    // 리지드바디2D 컴포넌트
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //void Start()
    //{
        
    //}

    //void Update()
    //{

    //}

    public void OnMove(InputAction.CallbackContext cotext)
    {
        if(cotext.phase == InputActionPhase.Started || cotext.phase == InputActionPhase.Performed)
        {
            moveDir = cotext.ReadValue<Vector2>();
            Debug.Log("입력");
        }
        else if(cotext.phase == InputActionPhase.Canceled)
        {
            moveDir = Vector2.zero;
        }

        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
