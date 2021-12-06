using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    public GameObject panelTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject buildEffect;
    private TurretBlueprint turretToBuild;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one Build Manager in scene!");
            return;
        }
        instance = this;
    }
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        PlayerStats.Money -= turretToBuild.cost;
        //Build a turret
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
