using UnityEngine;

public class buildManager : MonoBehaviour
{

    public static buildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one builder in scene");
            return;
        }
        instance = this;        
    }

    public GameObject standartTurretPrefab;

    void Start()
    {
        turrentToBuild = standartTurretPrefab;
    }

    private GameObject turrentToBuild;

    public GameObject getTurretToBuild()
    {
        return turrentToBuild;
    }
}
