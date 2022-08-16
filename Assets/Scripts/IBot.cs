using UnityEngine;

interface IBot : IObj
{
    void IncreaseDamage(int mod);

    void FindTarg();

    void Attach();

    void Generate();

    void AttackTarg(ObjScr targ);
}
