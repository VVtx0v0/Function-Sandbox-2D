using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerCycleCover : MonoBehaviour
{
    public GameObject[] Covers;
    public GameObject Projectile;
    public int CoverNum;
    


    private void Start()
    {
        CoverNum = 1;
        transform.position = Covers[CoverNum].transform.position ;
    }

    private void Update()
    {
        CycleCover();
        //test if projectile is not fucking me
        ShootProjectiles();
    }

    void CycleCover()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (CoverNum - 1 >= 0)
            {
                CoverNum--;
                transform.position = Covers[CoverNum].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (CoverNum + 1 <=4)
            {
                CoverNum++;
                transform.position = Covers[CoverNum].transform.position;
            }
        }
      
        
    }
    public void ShootProjectiles()
    {
        Instantiate(Projectile, transform.position, Quaternion.identity);
    }

}
