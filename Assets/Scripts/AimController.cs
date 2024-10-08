using UnityEngine;

public class AimController:MonoBehaviour
{
    public Transform target; // Ҫ����Ľ�ɫ
    public float distance = 5.0f; // Ĭ�Ͼ���
    public float minDistance = 2.0f; // ��С����
    public float maxDistance = 10.0f; // ������
    public float scrollSpeed = 2.0f; // �����������ٶ�
    public float rotationSpeed = 100.0f; // ��ת�ٶ�
    public Vector2 pitchLimits = new Vector2(-30, 60); // ����������
    public float rotateSmoothTime = 0.1f; // ��ɫ��תƽ��ʱ��

    public Transform camera;
    public Vector3 defaultPos;

    private float yaw = 0.0f; // ˮƽ��ת�Ƕ�
    private float pitch = 10.0f; // ��ֱ��ת�Ƕ�
    private Vector3 currentVelocity; // ����ƽ����ת


    void Update()
    {
        if (target == null) return;

        // ������������Կ�����ת
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // ������ת�Ƕ�
        yaw += mouseX * rotationSpeed * Time.deltaTime;
        pitch += mouseY * rotationSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);

        // ������������Ե������������
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        distance -= scrollInput * scrollSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // �����������ת���λ��
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);

        // ���������λ�úͳ���
        transform.position = target.position + offset;
        transform.LookAt(target.position);

        // ��ת��ɫ��ʹ���������������ͬ�ķ���
        Vector3 direction = new Vector3(transform.position.x, target.position.y, transform.position.z) - target.position;
        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            target.rotation = Quaternion.Slerp(target.rotation, targetRotation, rotateSmoothTime);
        }

    }
}