using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class PlayerStateList : MonoBehaviour
{
    public bool jumping = false;
    public bool dashing = false;
    public bool recoilingX, recoilingY;
    public bool lookingRight;
    public bool invincible;
    public bool healing;
    public bool casting;
    public bool cutscene = false;
}
