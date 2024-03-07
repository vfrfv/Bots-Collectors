using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB : MonoBehaviour
{
    List<Base> _bases;
    
    public void AddBase(Base @base) { _bases.Add(@base);}
}
