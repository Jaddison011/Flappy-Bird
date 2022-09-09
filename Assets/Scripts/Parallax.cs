using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;
    public float originalAnimationSpeed;

    // Ran on initialisation
    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        originalAnimationSpeed = animationSpeed;
    }

    private void Update() {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }

    public void ResetSpeed() {
        animationSpeed = originalAnimationSpeed;
    }
}
