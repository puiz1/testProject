using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudAnim : MonoBehaviour
{
    public float currOpacity;
    public float fadeSpeed;
    public bool ping;
    public Renderer rend;

    public float atlasPosition;
    public float[] vValue = { 0f, 0.25f, 0.5f, 0.75f };
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        currOpacity = Random.Range(0.05f, 0.95f);
        ChangeVPos();
    }

    // Update is called once per frame
    void Update()
    {
        Color currColor = new Color(1, 1, 1, currOpacity);
        rend.material.SetColor("_Color", currColor);
        if (ping)
        {
            fadeSpeed = 0.35f;
        }
        else
        {
            fadeSpeed = -0.35f;
        }
        currOpacity += Time.deltaTime * fadeSpeed;
        if(currOpacity > 1f)
        {
            ping = !ping;
        }
        else if(currOpacity < 0f)
        {
            ping = !ping;
            ChangeVPos();
        }
    }

    void ChangeVPos()
    {
        atlasPosition = vValue[Random.Range(0, 3)];
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, atlasPosition));
    }
}
