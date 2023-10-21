using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer rend;

    private void Update()
    {
        rend.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}