using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class GalleryManager : MonoBehaviour
{
    public RectTransform galleryContainer;
    public GameObject imagePrefab;
    public float spacing = 10f;

    private int imageCount = 66;
    private int imagesPerRow = 2;
    private int currentImageIndex = 0;
    private float imageWidth;
    private float imageHeight;

    private void Start()
    {
        imageWidth = (galleryContainer.rect.width - (spacing * (imagesPerRow - 1))) / imagesPerRow;
        imageHeight = imageWidth;

        LoadImages();
    }

    private void LoadImages()
    {
        for (int i = 0; i < imageCount; i++)
        {
            GameObject imageObj = Instantiate(imagePrefab, galleryContainer);
            imageObj.GetComponent<RectTransform>().sizeDelta = new Vector2(imageWidth, imageHeight);

            // Загрузка изображения по URL
            string imageUrl = "http://data.ikppbb.com/test-task-unity-data/pics/" + i + ".jpg";
            StartCoroutine(LoadImageFromURL(imageUrl, imageObj.GetComponent<Image>()));

            currentImageIndex = i + 1;
        }
    }

    private IEnumerator LoadImageFromURL(string url, Image imageComponent)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to load image: " + www.error);
            yield break;
        }

        Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        imageComponent.sprite = sprite;
    }
}
