namespace CodeBase.Interfaces
{
    public interface IHealth
    {
        int Max { set; get; }
        int Current { set; get; }
        void TakeDamage(int damage);
    }
}