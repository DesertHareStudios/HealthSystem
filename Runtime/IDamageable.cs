public interface IDamageable {

    public void Damage(float ammount);
    public void Heal(float ammount);
    public void Kill();
    public void Revive(float ratio = 1f);

}