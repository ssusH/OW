using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleUI : MonoBehaviour {

    public Text MaxHp;
    public Text CurrentHp;
    public Image HpBar;

    public Text MaxBullte;
    public Text CurrentBullte;

    private PlayerSetup _Setup;
    private PlayerState _player;
    private Weapon _weapon;


    public void SetPlayerSetUp(PlayerSetup setup)
    {
        _Setup = setup;
    }
    public void SetDefaultUI(PlayerState player, Weapon weapon)
    {
        _player = player;
        _weapon = weapon;
        SetDefaultHp(_player.GetMaxHealth());
        SetDefaultBullte(weapon.GetMaxButtleSum());
    }

    private void Start()
    {
        _Setup.SetBattleUIDefault(this);
    }

    // Update is called once per frame
    void Update () {
        UpdateCurrentHp();
        UpdateCurrentBullte();

    }

    void UpdateCurrentBullte()
    {
        if (_weapon == null)
            return;
        CurrentBullte.text = _weapon.GetCurrentButtleSum().ToString();
    }

    void UpdateCurrentHp()
    {
        if (_player == null)
            return;
        
        CurrentHp.text = _player.GetCurrentHealth().ToString();
        HpBar.rectTransform.localScale = new Vector3( _player.NowHealthPercent(),1);

    }

    

    public void SetDefaultHp(float MaxHpValue)
    {
        MaxHp.text = "/" + MaxHpValue.ToString();
        CurrentHp.text = MaxHpValue.ToString();
    }

    public void SetDefaultBullte(int MaxBullteValue)
    {
        MaxBullte.text = "/" + MaxBullteValue.ToString();
        CurrentBullte.text = MaxBullteValue.ToString();
        
    }




}
