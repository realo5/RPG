using RPG.Engine.Entities;

namespace RPG.Engine.Interfaces
{
    public interface IHitDie
    {
        HitDie HD { get; set; }
        int Roll();
    }
}
