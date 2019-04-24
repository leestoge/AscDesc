using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float scroll_Speed = 0.3f;

    private MeshRenderer _meshRenderer;

    private string bg = "_MainTex";

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = _meshRenderer.sharedMaterial.GetTextureOffset(bg);
        offset.y += Time.deltaTime * scroll_Speed;

        _meshRenderer.sharedMaterial.SetTextureOffset(bg, offset);
    }
}
