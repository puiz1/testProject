using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destHS : MonoBehaviour
{
    public Vector2[] UVOffsets;
    public int currArrayPos;
    public float interval = 0.1f;
    public Renderer rend;

    public bool UVTileSwitch;
    public float currTile;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        InvokeRepeating("NextStage", 1, interval);
    }

    // Update is called once per frame
    void Update()
    {
        if(UVTileSwitch)
        {
            currTile = 0.5f;
        }
        else
        {
            currTile = 0.25f;
        }
    }

    void NextStage()
    {
        currArrayPos++;
        if (currArrayPos > UVOffsets.Length - 1)
        {
            currArrayPos = 0;
        }
        rend.material.SetTextureOffset("_MainTex", UVOffsets[currArrayPos]);
    }
}
