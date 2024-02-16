using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 角色的 Transform 组件

    public Vector3 offset; // 相机与角色之间的偏移量

    public float smoothSpeed = 0.125f; // 相机跟随的平滑速度

    public float sensitivity = 8.0f;  // 鼠标灵敏度

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // 锁定鼠标在屏幕中心
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;  // 获取鼠标在水平方向上的移动
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;  // 获取鼠标在垂直方向上的移动

        float targetRotationX = target.rotation.eulerAngles.x; // 获取角色当前绕X轴的旋转角度

        target.Rotate(Vector3.up, mouseX);  // 绕角色对象的 Y 轴旋转

        Matrix4x4 m = Matrix4x4.Rotate(target.rotation * Quaternion.Euler(targetRotationX + mouseY, 0, 0)); // 构造绕目标合并鼠标Y轴旋转的矩阵
        Vector3 rotatedOffset = m * offset; // 将偏移量应用于旋转矩阵
        Vector3 desiredPosition = target.position + rotatedOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
