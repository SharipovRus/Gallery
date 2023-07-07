using UnityEngine;

public class FreeAspect : MonoBehaviour
{
    private void Start()
    {
        // Разрешаем автоматическую ориентацию
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
