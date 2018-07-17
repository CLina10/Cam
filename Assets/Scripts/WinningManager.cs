using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningManager : MonoBehaviour
{
    public EnemyCount count;

    Animator anim;
    bool won;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (won == false && EnemyCount.count == 1)
        {
            won = true;
            //print("Win");
            anim.SetTrigger("Winning");
        }
    }
}
