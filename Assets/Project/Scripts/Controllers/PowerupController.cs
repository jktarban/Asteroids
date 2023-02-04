using TypeReferences;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [SerializeField]
    [Inherits(typeof(IPowerup))]
    private TypeReference powerupType;

    public string PowerupName => powerupType.Type.Name;
}
