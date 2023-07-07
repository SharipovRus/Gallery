using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    public static List<RectTransform> ObjectsImage;
    public static List<Sprite> SpritesUploadedWithURL;
    
    public ScrollRect scrollRect; //скролл компонент
    [SerializeField] private RectTransform prefabImage; // префаб изображения
    [SerializeField] private RectTransform content; // скачанные изображения
    [SerializeField] private GameObject maxPanel; // изображение во весь экран
    [SerializeField] private Button returnButton; //кнопка возврата

    private ManagerExternalResources _managerExternalResources;
    
    private void Awake()
    {
        ObjectsImage = new List<RectTransform>();
        SpritesUploadedWithURL = new List<Sprite>();
        _managerExternalResources = new ManagerExternalResources(this);
        
        returnButton.onClick.AddListener(ReturnToGallery); // Добавляем метод ReturnToGallery к событию нажатия кнопки
    }

    public void Spawn()
    {
        _managerExternalResources.DownloadNextTexture2D(CreateImage);
    }
    
    public void CreateImage(Texture2D texture2D)
    {
        if (texture2D == null) return;
        
        var sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height),
            new Vector2(0.5f, 0.5f));
        SpritesUploadedWithURL.Add(sprite);
        var obj = Instantiate(prefabImage, transform.position, Quaternion.identity);
        ObjectsImage.Add(obj);
        obj.GetComponent<Image>().sprite = sprite;
        obj.transform.SetParent(content.transform);
        obj.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        obj.name = "Image_" + _managerExternalResources.GetLastNumberSprite();
        obj.GetComponent<ImageHandler>().MaxPanel = maxPanel;
        Debug.Log("Create sprite " + _managerExternalResources.GetLastNumberSprite() );
    }
    
    public void ReturnToGallery()
    {
        maxPanel.SetActive(false);
    }
}
