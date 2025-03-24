using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    public int targetWidth = 1080;  // ���ϴ� ���� �ػ�
    public int targetHeight = 1920; // ���ϴ� ���� �ػ�
    private int screenshotCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // P Ű�� ���� ��ũ���� �Կ�
        {
            string folderPath = Application.persistentDataPath + "/Screenshots/";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = "screenshot_" + screenshotCount + ".png";
            string fullPath = Path.Combine(folderPath, fileName);

            float scaleFactor = Mathf.Max((float)targetWidth / Screen.width, (float)targetHeight / Screen.height);
            ScreenCapture.CaptureScreenshot(fullPath, Mathf.CeilToInt(scaleFactor));
            screenshotCount++;

            Debug.Log("��ũ���� �����: " + fullPath);
        }
    }
}
