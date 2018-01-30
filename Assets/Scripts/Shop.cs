using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurert;
    public TurretBlueprint missleLauncher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard turet selected");
        buildManager.SelectTurretToBuild(standardTurert);
    }

    public void SelectMissleLauncher()
    {
        Debug.Log("Missle launcher selected");
        buildManager.SelectTurretToBuild(missleLauncher);
    }
}
