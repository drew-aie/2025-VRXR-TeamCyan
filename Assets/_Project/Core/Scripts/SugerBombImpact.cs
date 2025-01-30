using System.Collections;
using UnityEngine;

public class SugarBombImpact : MonoBehaviour
{
    [Header("Shader Effect")]
    [SerializeField] private GameObject shaderEffectPrefab; // Assign an explosion or glow effect prefab
    [SerializeField] private float effectDuration = 2f; // Duration before the effect disappears
    [SerializeField] private LayerMask groundLayer; // Layer mask for detecting ground impact

    private bool hasExploded = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Sugar Bomb collided with: {collision.gameObject.name}, Layer: {collision.gameObject.layer}");

        // Check if it hit the ground and prevent multiple activations
        if (!hasExploded && ((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            hasExploded = true;
            Debug.Log("Sugar Bomb hit the ground! Triggering shader effect...");
            PlayShaderEffect(collision.contacts[0].point);
            StartCoroutine(DestroyAfterEffect());
        }
        else
        {
            Debug.Log("Collision detected, but not with the ground.");
        }
    }

    private void PlayShaderEffect(Vector3 impactPoint)
    {
        if (shaderEffectPrefab != null)
        {
            GameObject effectInstance = Instantiate(shaderEffectPrefab, impactPoint, Quaternion.identity);
            effectInstance.transform.up = Vector3.up; // Align effect with the ground
            Debug.Log($"Shader effect instantiated at {impactPoint}");
        }
        else
        {
            Debug.LogWarning("Shader effect prefab is not assigned!");
        }
    }

    private IEnumerator DestroyAfterEffect()
    {
        Debug.Log($"Sugar Bomb will be destroyed in {effectDuration} seconds...");
        yield return new WaitForSeconds(effectDuration);
        Debug.Log("Destroying Sugar Bomb.");
        Destroy(gameObject); // Destroy the Sugar Bomb after effect duration
    }
}
