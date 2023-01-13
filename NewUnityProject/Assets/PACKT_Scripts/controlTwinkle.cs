using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTwinkle : MonoBehaviour
{
    public bool switched;
    public float frequency = 0.2f;
    public Texture2D origAlbedo;
    public Texture2D newAlbedo;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Switch", frequency, frequency);
    }

    // Update is called once per frame
    void Update()
    {
        if(switched)
        {
            GetComponent<Renderer>().material.SetTexture("_MainTex", newAlbedo);
        }
        else
        {
            GetComponent<Renderer>().material.SetTexture("_MainTex", origAlbedo);
        }
    }
    void Switch()
    {
        switched = !switched;
    }
}
