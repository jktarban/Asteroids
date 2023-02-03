using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoSingleton<HealthManager> {
    [SerializeField]
    private PlayerSO playerSettings;
    [SerializeField]
    private Image healthFillImage;

    private int _healthValue;

    public void DeductHealth() {
        _healthValue--;
        healthFillImage.fillAmount = (float)_healthValue / (float)playerSettings.Health;
    }

    private void Start() {
        _healthValue = playerSettings.Health;
        healthFillImage.fillAmount = 1f;
    }
}
