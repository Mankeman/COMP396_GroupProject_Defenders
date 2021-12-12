using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint panelTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint standardTurret;
    public TurretBlueprint laserBeamer;
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectStandardTurret();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectPanelTurret();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectMissileLauncher();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectLaserBeamer();
        }
    }
    public void SelectPanelTurret()
    {
        buildManager.SelectTurretToBuild(panelTurret);
    }
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
