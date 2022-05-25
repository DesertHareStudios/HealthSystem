using UnityEngine;

public class DamageMultiplier : MonoBehaviour, IDamageable {

    [SerializeField] private IDamageable parent;
    [SerializeField] private float multiplier = 1f;

    private void Awake() {
        if(parent == null) {
            parent = GetComponentInParent<IDamageable>();
        }
    }

    public void Damage(float ammount) {
        parent.Damage(ammount + multiplier);
    }

    public void Heal(float ammount) {
        parent.Heal(ammount);
    }

    public void Kill() {
        parent.Kill();
    }

    public void Revive(float ratio = 1) {
        parent.Revive(ratio);
    }
}