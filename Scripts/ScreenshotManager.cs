using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    public int targetWidth = 1080;  // 원하는 가로 해상도
    public int targetHeight = 1920; // 원하는 세로 해상도
    private int screenshotCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // P 키를 눌러 스크린샷 촬영
        {
            string folderPath = Application.persistentDataPath + "/Screenshots/";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = "screenshot_" + screenshotCount + ".png";
            string fullPath = Path.Combine(folderPath, fileName);

            float scaleFactor = Mathf.Max((float)targetWidth / Screen.width, (float)targetHeight / Screen.height);
            ScreenCapture.CaptureScreenshot(fullPath, Mathf.CeilToInt(scaleFactor));
            screenshotCount++;

            Debug.Log("스크린샷 저장됨: " + fullPath);
        }
    }
}
