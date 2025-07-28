using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager instance;

    public GameObject shoteffect;
    public GameObject GunSmokeEffect;

    private void Awake()
    {
        instance = this;
    }

    public void PlayEffect(GameObject effect, Vector2 position, Quaternion rotation)
    {
        Instantiate(effect, position, rotation);
    }

}
