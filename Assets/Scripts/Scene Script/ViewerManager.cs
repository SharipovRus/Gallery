using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViewerManager : MonoBehaviour
{
    public Image imageView;

    private Sprite selectedImage;

    public void SetImage(Sprite image)
    {
        selectedImage = image;
        imageView.sprite = selectedImage;
    }

    public void GoBackToGallery()
    {
        SceneManager.LoadScene("GameScene");
    }
}
