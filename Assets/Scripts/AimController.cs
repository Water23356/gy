using UnityEngine;

public class AimController:MonoBehaviour
{
    public Transform target; // 要跟随的角色
    public float distance = 5.0f; // 默认距离
    public float minDistance = 2.0f; // 最小距离
    public float maxDistance = 10.0f; // 最大距离
    public float scrollSpeed = 2.0f; // 鼠标滚轮缩放速度
    public float rotationSpeed = 100.0f; // 旋转速度
    public Vector2 pitchLimits = new Vector2(-30, 60); // 俯仰角限制
    public float rotateSmoothTime = 0.1f; // 角色旋转平滑时间

    public Transform camera;
    public Vector3 defaultPos;

    private float yaw = 0.0f; // 水平旋转角度
    private float pitch = 10.0f; // 垂直旋转角度
    private Vector3 currentVelocity; // 用于平滑旋转


    void Update()
    {
        if (target == null) return;

        // 处理鼠标输入以控制旋转
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 计算旋转角度
        yaw += mouseX * rotationSpeed * Time.deltaTime;
        pitch += mouseY * rotationSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);

        // 处理滚轮缩放以调整摄像机距离
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        distance -= scrollInput * scrollSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // 计算摄像机旋转后的位置
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);

        // 更新摄像机位置和朝向
        transform.position = target.position + offset;
        transform.LookAt(target.position);

        // 旋转角色，使其面向与摄像机相同的方向
        Vector3 direction = new Vector3(transform.position.x, target.position.y, transform.position.z) - target.position;
        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            target.rotation = Quaternion.Slerp(target.rotation, targetRotation, rotateSmoothTime);
        }

    }
}