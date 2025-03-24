using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Controller : MonoBehaviour
{
    [SerializeField]
    private Transform go_Floor; // �ٴ� ������Ʈ

    [SerializeField]
    private float rotationSpeed; // ȸ�� �ӵ�

    private float targetAngle = 0f; // ��ǥ ȸ�� ����
    private bool isPressLeft = false;
    private bool isPressRight = false;

    private void Update()
    {
        // ���� ��ư�� ���� ������ �������� ȸ��
        if (isPressLeft)
        {
            targetAngle = Mathf.Clamp(targetAngle + rotationSpeed * Time.deltaTime * 10f, -20f, 20f);
        }
        // ������ ��ư�� ���� ������ ���������� ȸ��
        if (isPressRight)
        {
            targetAngle = Mathf.Clamp(targetAngle - rotationSpeed * Time.deltaTime * 10f, -20f, 20f);
        }

        // ��ǥ ������ �ε巴�� ȸ��
        float currentAngle = go_Floor.eulerAngles.z;
        if (currentAngle > 180f) currentAngle -= 360f; // -180 ~ 180 ������ ��ȯ
        float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
        go_Floor.rotation = Quaternion.Euler(0, 0, newAngle);
    }

    // ���� ��ư Ŭ�� �� ȣ��
    public void DownRotateLeft()
    {
        isPressLeft = true;
    }

    // ���� ��ư���� Ŭ�� �׸� ������ ȣ��
    public void UpRotateLeft()
    {
        isPressLeft = false;
    }

    // ������ ��ư Ŭ�� �� ȣ��
    public void DownRotateRight()
    {
        isPressRight = true;
    }

    // ������ ��ư���� Ŭ�� �׸� ������ ȣ��
    public void UpRotateRight()
    {
        isPressRight = false;
    }
}
