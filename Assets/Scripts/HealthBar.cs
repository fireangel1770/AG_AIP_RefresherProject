using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] HealthSO health;
    UnityEngine.UI.Image healthBarImage;
    private void Start()
    { 
        healthBarImage = GetComponent<UnityEngine.UI.Image>();
    }
    private void Update()
    {
        healthBarImage.fillAmount = health.currentHealth / health.maxHealth;
    }

}
