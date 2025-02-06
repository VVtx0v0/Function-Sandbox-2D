using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevDoodleMaster : MonoBehaviour
{
    public DevDoodler DoodlerPrefab;
    DevDoodler _currentDoodler;
    int _DoodleSortOrder = 50;
    public List<Vector3> AccPointPositions;

    public GameObject AccPointPrefab;


    //Player reference

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _currentDoodler = Instantiate(DoodlerPrefab, this.transform); // instantiate as a child of the doodle master.
            _DoodleSortOrder += 1;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _currentDoodler.SetLineColor(Color.cyan, 0.5f); //and destroy edge collider
            AccPointPositions = _currentDoodler.GenerateAccuracyPoints();
            GameObject accpointParent = new GameObject();
            accpointParent.name = "AccPoints";
            int count = 0;
            foreach (Vector3 t in AccPointPositions)
            {
             GameObject currentPoint=   Instantiate(AccPointPrefab, t, Quaternion.identity, accpointParent.transform);
                currentPoint.name = "point" + count;
                count++;
            }
            //-- CODE TO DETECT A CLOSED SHAPE HERE 

            Collider2D lastPoint = accpointParent.transform.GetChild(accpointParent.transform.childCount - 1).GetComponent<Collider2D>();
          //  print("THE LAST POINT IS:" + lastPoint.name);
            _currentDoodler = null;

            bool attackSuccesful = false; 
            for(int i = 0; i < transform.childCount; i++)
            {
                Collider2D firstTenPoint = accpointParent.transform.GetChild(i).GetComponent<CircleCollider2D>();
                if (lastPoint.bounds.Intersects(firstTenPoint.bounds)){
                    print("LOOP!");
                    break;
                }
                else
                {
                    print("failed");
                }


            }
            if (attackSuccesful)
            {
                //do stuff
                //destroy
            
            }
            else
            {
                
            }
        }
        if (_currentDoodler != null)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _currentDoodler.UpdateLine(mousepos);

        }
    }
}
