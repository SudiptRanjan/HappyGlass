using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal; // Import URP-specific namespaces

[ExecuteInEditMode]
public class URPBlurController : MonoBehaviour
{
    [Header("Blur Settings")]
    public int iterations = 3;       // Blur iterations - larger number means more blur.
    public float blurSpread = 0.6f;  // Blur spread for each iteration. Lower values give better-looking blur.
    public Material blurMaterial;    // Assign your URP-compatible blur material here.

    public UniversalRenderPipelineAsset urpAsset; // Reference to your URP asset.

    private void OnEnable()
    {
        // Set the URP asset to allow post-processing.
        GraphicsSettings.renderPipelineAsset = urpAsset;
    }

    private void OnDisable()
    {
        // Reset the render pipeline asset when disabling the script.
        GraphicsSettings.renderPipelineAsset = null;
    }

    // Called by the camera to apply the image effect
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        int rtW = source.width / 4;
        int rtH = source.height / 4;
        RenderTexture buffer = RenderTexture.GetTemporary(rtW, rtH, 0);

        // Copy source to the 4x4 smaller texture.
        Graphics.Blit(source, buffer);

        // Blur the small texture
        for (int i = 0; i < iterations; i++)
        {
            RenderTexture buffer2 = RenderTexture.GetTemporary(rtW, rtH, 0);
            buffer2.DiscardContents(); // For URP, ensure the RenderTexture is cleared.
            Graphics.Blit(buffer, buffer2, blurMaterial);
            RenderTexture.ReleaseTemporary(buffer);
            buffer = buffer2;
        }
        Graphics.Blit(buffer, destination);
        RenderTexture.ReleaseTemporary(buffer);
    }
}
