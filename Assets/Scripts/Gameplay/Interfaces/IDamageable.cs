using Pethalyse.Gameplay.Enum;

namespace Pethalyse.Gameplay.Interfaces
{
    public interface IDamageable
    {
        void Damage(int amount, EnumDamageType damageType);
        void DamageBrut(int amount);
    }
}