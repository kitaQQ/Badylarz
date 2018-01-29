﻿using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More then one build maganer in scene");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missleLauncherPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
