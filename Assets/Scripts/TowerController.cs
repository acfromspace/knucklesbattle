﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
	//public static TowerController instance;
	public int health = 100; //health points
	private int maxHealth = 100;
	private float cooldownTime = 10.0f;
	
	private int knucklesDamage; //placebo variable for knuckles damage value from Knuckles Controller
    public int Health { get { return health; } }
    public int MaxHealth { get { return maxHealth; } }

	public Image cooldownImageAlpha;

	[SerializeField]
	private AmmoPlatformController m_AmmoPlatformController;



	//HUDController HUD = HUDController.instance.towerHealthBarSlider;
	
	// Use this for initialization
	void Start () {
		cooldownImageAlpha.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (m_AmmoPlatformController.AmmoCooldown);
		if (m_AmmoPlatformController.AmmoCooldown)
		{
			cooldownImageAlpha.enabled = true;
			cooldownImageAlpha.fillAmount -= 1.0f / cooldownTime * Time.deltaTime;
			if (cooldownImageAlpha.fillAmount == 0) {
				m_AmmoPlatformController.AmmoCooldown = false;
				cooldownImageAlpha.enabled = false;
				cooldownImageAlpha.fillAmount = 1;
			}
		}
	}

    /// <summary>
    /// Initiates the cooldown.
    /// </summary>
    public void InitiateCooldown()
    {
		
        //TODO Implement cooldown code.
    }

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "KnucklesTest")
		{
			health -= 1;
			
			//Debug.Log(HUDtowerHealthBarSlider);
			
			Debug.Log("Knuckle collided with tower damaging it");
			//HP -= knucklesDamage;
		}	
	}

	
}
