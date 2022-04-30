using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBWheel : MonoBehaviour
{
    [SerializeField] SpriteRenderer ColorPickerSprite_Optional;
    [SerializeField] SpriteRenderer ColorPickedSprite;

    [SerializeField] Texture2D texture;
    public Color selectedColor;

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,100))
        {
            Vector2 uv = hit.textureCoord;
            uv.x *= texture.width;
            uv.y *= texture.height;
            Color color = texture.GetPixel(Mathf.FloorToInt(uv.x), Mathf.FloorToInt(uv.y));
            ColorPickerSprite_Optional.color = color;   //Optional

            if (Input.GetMouseButton(0))
            {
                selectedColor = color;
                ColorPickedSprite.color = selectedColor;
            }
        }
    }
}