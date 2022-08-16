using UnityEngine;

interface IBot : IObj
{
    void IncreaseDamage(int mod);

    void FindTarg();

    void Attach(ObjData targ);

    void Generate();
}
