using UnityEngine;

[CreateAssetMenu(fileName = "HealthSO", menuName = "Scriptable Objects/HealthSO")]
public class HealthSO : ScriptableObject
{
    public float currentHealth;
    public float maxHealth;

    public void SetFullHealth()
    {
        currentHealth = maxHealth;
    }
    public void DoDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount , 0, maxHealth);
    }
}
