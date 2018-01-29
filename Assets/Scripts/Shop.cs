﻿using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turet selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissleLauncher()
    {
        Debug.Log("Missle launcher selected");
        buildManager.SetTurretToBuild(buildManager.missleLauncherPrefab);
    }
}
