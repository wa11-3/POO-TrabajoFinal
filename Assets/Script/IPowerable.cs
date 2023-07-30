using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerable
{
    public string power { set; get; }
    public void SetPowerUp();
}
