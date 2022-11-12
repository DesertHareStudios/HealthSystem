using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable {

    [SerializeField] private float BaseHealth = 100f;

    public UnityEvent<float> OnDamage;
    public UnityEvent<float> OnHeal;
    public UnityEvent OnDeath;
    public UnityEvent OnRevive;

    private float currentHealth = 100f;

    public float CurrentHealth {
        get {
            return currentHealth;
        }
        protected set {
            currentHealth = Mathf.Clamp(value, 0f, BaseHealth);
        }
    }

    public float HealthRatio {
        get {
            return CurrentHealth / BaseHealth;
        }
        protected set {
            CurrentHealth = BaseHealth * value;
        }
    }

    public bool IsAlive {
        get {
            return CurrentHealth > 0f;
        }
    }

    private void OnEnable() {
        CurrentHealth = BaseHealth;
    }

    private void OnDisable() {
        CurrentHealth = 0f;
    }

    public void Damage(float ammount) {
        CurrentHealth -= ammount;
        OnDamage?.Invoke(ammount);
        if(CurrentHealth <= 0f) {
            OnDeath?.Invoke();
        }
    }

    public void Heal(float ammount) {
        CurrentHealth += ammount;
        OnHeal?.Invoke(ammount);
        if(CurrentHealth <= 0f) {
            OnDeath?.Invoke();
        }
    }

    public void Kill() {
        CurrentHealth = 0f;
        OnDamage?.Invoke(BaseHealth);
        OnDeath?.Invoke();
    }

    public void Revive(float ratio = 1f) {
        if(!IsAlive) {
            return;
        }
        HealthRatio = ratio;
        OnHeal?.Invoke(CurrentHealth);
        OnRevive?.Invoke();
    }
}