using UnityEngine;

public class Portrait : MonoBehaviour
{
    private void Start()
    {
        // Установка ориентации сцены в портретную
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Update()
    {
        // Проверка текущей ориентации устройства и перевод в портретную, если она была изменена
        if (Screen.orientation != ScreenOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
