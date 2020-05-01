using UnityEngine;

public class ResManager : MonoBehaviour
{
    private ResManager() { }
    
    public static GameObject LoadPrefab(string path)
    {
        return Resources.Load<GameObject>(path);
    }
}
