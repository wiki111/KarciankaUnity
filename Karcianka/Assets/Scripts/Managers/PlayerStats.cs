using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public PlayerHolder player;
    public Image avatar;
    public Text hp;
    public Text name;

    // Use this for initialization
    void Start () {
        UpdateName();
        UpdateHealth();
        player.playerStats = this;
	}

    public void UpdateName()
    {
        name.text = player.name;
    }

    public void UpdateHealth()
    {
        hp.text = player.health.ToString();
    }

    public void UpdateAvatar()
    {
        avatar.sprite = player.avatar;
    }
    
    public void UpdateAll()
    {
        UpdateHealth();
        UpdateName();
    }
}
