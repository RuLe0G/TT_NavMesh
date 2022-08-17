/// <summary>
/// базовый интерфейс бота
/// </summary>
interface IBot : IObj
{
    void IncreaseDamage(int mod);

    void FindTarg();

    void Attach();

    void Generate();

    void AttackTarg(EntentyScr targ);
}
