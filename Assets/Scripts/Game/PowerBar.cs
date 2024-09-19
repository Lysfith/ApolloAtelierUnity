using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Image Value;
    public float Speed = 1;

    private float _power;
    private bool _goUp;
    private bool _powerSelection;

    void Start()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        if(!_powerSelection)
        {
            return;
        }

        if (_power <= 0)
        {
            _power = 0;
            _goUp = true;
        }
        else if (_power >= 1)
        {
            _power = 1;
            _goUp = false;
        }

        _power += (_goUp ? 1 : -1) * Speed * Time.deltaTime;

        Value.fillAmount = _power;
    }

    public void StartPowerSelection()
    {
        _power = 0;
        Value.fillAmount = _power;
        gameObject.SetActive(true);
        _powerSelection = true;
    }

    public void StopPowerSelection()
    {
        _powerSelection = false;
    }

    public void HidePowerBar()
    {
        gameObject.SetActive(false);
    }

    public float GetPower(){
        return _power;
    }
}
