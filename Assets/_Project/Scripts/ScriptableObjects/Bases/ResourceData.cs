using UnityEngine;

[CreateAssetMenu(fileName ="Resource/ResourceData")]
public class ResourceData : ScriptableObject
{
    public string Name;
    public string Description;
    public int Current;
    public int Max;
    public int RegenAmount;
    public int RegenRate;
}
