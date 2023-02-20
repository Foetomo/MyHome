using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private RawImage background;

    [SerializeField]
    private float x, y;

    // Update is called once per frame
    private void Start()
    {
        
    }

    void Update()
    {
        BackgroundBergerak();
    }

    private void BackgroundBergerak()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(x, y) * Time.deltaTime, background.uvRect.size);
    }
}
