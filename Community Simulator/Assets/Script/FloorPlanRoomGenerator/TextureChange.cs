using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange : MonoBehaviour
{

    public Texture[] textures;
    public int currentTexture;
    public Texture textureSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void textC(int num)
    {
        GetComponent<Renderer>().sharedMaterial.mainTexture = textures[num];
    } 
}
