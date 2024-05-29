using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ImageScrollController : MonoBehaviour
{
    public UnityEngine.UI.Image[] imageSlots; // An array of Image components to hold the images

    void Start()
    {
        // Load images and assign them to the Image components
        for (int i = 0; i < imageSlots.Length; i++)
        {
            // Load image from Resources folder (replace "imageName" with your image name)
            Sprite imageSprite = Resources.Load<Sprite>("imageName" + (i + 1));

            // Assign the loaded image sprite to the Image component
            if (imageSprite != null)
            {
                imageSlots[i].sprite = imageSprite;
            }
            else
            {
                Debug.LogError("Image not found at Resources/imageName" + (i + 1));
            }
        }
    }
}
