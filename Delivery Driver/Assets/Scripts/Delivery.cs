using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private LayerMask packagesLayerMask;
    [SerializeField] private LayerMask customersLayerMask;

    [SerializeField] private GameObject playerCarVisuals;

    private SpriteRenderer spriteRenderer;
    private Color32 basicColor = Color.white;

    private bool hasPackage = false;
    private string packageColor;

    private void Start()
    {
        spriteRenderer = playerCarVisuals.GetComponent<SpriteRenderer>();
        spriteRenderer.color = basicColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int) Mathf.Log(packagesLayerMask.value, 2) && !hasPackage) 
        {
            hasPackage = true;
            packageColor = collision.tag;

            spriteRenderer.color = collision.GetComponent<SpriteRenderer>().color;

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == (int) Mathf.Log(customersLayerMask.value, 2) && hasPackage && packageColor == collision.tag)
        {
            hasPackage = false;
            spriteRenderer.color = basicColor;
        }
    }
}
