//用箭头键控制角色移动，当按下空格键时跳起。
using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    private Animator animator; // 动画控制器

    void Start()
    {
        animator = GetComponent<Animator>(); // 获取角色的动画控制器
    }

    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            //我们着地了，所以直接通过轴重新计算moveDirection。
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // 跳跃
            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
                animator.SetBool("IsJump", true);
            } else {
                animator.SetBool("IsJump", false);
            }

            // 设置动画参数
            if (moveDirection.magnitude > 0) {
                animator.SetBool("IsRunning", true); // 播放走路动画
            } else {
                animator.SetBool("IsRunning", false); // 停止走路动画
            }

            // 检查是否按下了鼠标左键
            if (Input.GetMouseButtonDown(0)) // 0代表鼠标左键
            {
                // Debug.Log("mousr down");
                // 设置Animator的Trigger，以播放攻击动画
                // 假设你的Trigger名字叫做"Attack"
                animator.SetBool("Attack", true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("Attack", false);
            }
        }

        //Move方法需要自己写重力效果
        moveDirection.y -= gravity * Time.deltaTime;

        //移动控制器
        controller.Move(moveDirection * Time.deltaTime);
    }
}