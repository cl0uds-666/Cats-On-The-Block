using UnityEngine;

public class Cover_Points : MonoBehaviour
{
     public Transform Point1;
     public Transform Point2;
     public Transform Point3;
     public Transform Point4;
     public Transform Point5;
     public Transform Point6;
     public Transform Point7;
    public Transform Point8;
    public GameObject Enemy;
    void Start()
    {
        Point1 = transform.Find("Point1");
        Point2 = transform.Find("Point2");
        Point3 = transform.Find("Point3");
        Point4 = transform.Find("Point4");
        Point5 = transform.Find("Point5");
        Point6 = transform.Find("Point6");
        Point7 = transform.Find("Point7");
        Point8 = transform.Find("Point8");

        if (Point1 != null)
        {
            Point1.transform.position = new Vector3(Point1.transform.position.x - 0.5f * transform.localScale.x + Enemy.transform.localScale.x / 2f, Point1.transform.position.y, Point1.transform.position.z - transform.localScale.z / 2f - 1f);
        }

        if (Point2 != null)
        {
            Point2.transform.position = new Vector3(Point2.transform.position.x - 0.5f * transform.localScale.x + Enemy.transform.localScale.x / 2f, Point2.transform.position.y, Point2.transform.position.z + transform.localScale.z / 2f + 1f);
        }

        if (Point3 != null)
        {
            Point3.transform.position = new Vector3(Point3.transform.position.x + 0.5f * transform.localScale.x - Enemy.transform.localScale.x / 2f, Point3.transform.position.y, Point3.transform.position.z - transform.localScale.z / 2f - 1f);
        }

        if (Point4 != null)
        {
            Point4.transform.position = new Vector3(Point4.transform.position.x + 0.5f * transform.localScale.x - Enemy.transform.localScale.x / 2f, Point4.transform.position.y, Point4.transform.position.z + transform.localScale.z / 2f + 1f);
        }

        if (Point5 != null)
        {
            Point5.transform.position = new Vector3(Point5.transform.position.x - transform.localScale.x / 2f - 1f, Point5.transform.position.y, Point5.transform.position.z - 0.5f * transform.localScale.z + Enemy.transform.localScale.z / 2f);
        }

        if (Point6 != null)
        {
            Point6.transform.position = new Vector3(Point6.transform.position.x + transform.localScale.x / 2f + 1f, Point6.transform.position.y, Point6.transform.position.z - 0.5f * transform.localScale.z + Enemy.transform.localScale.z / 2f);
        }

        if (Point7 != null)
        {
            Point7.transform.position = new Vector3(Point7.transform.position.x - transform.localScale.x / 2f - 1f, Point7.transform.position.y, Point7.transform.position.z + 0.5f * transform.localScale.z - Enemy.transform.localScale.z / 2f);
        }

        if (Point8 != null)
        {
            Point8.transform.position = new Vector3(Point8.transform.position.x + transform.localScale.x / 2f + 1f, Point8.transform.position.y, Point8.transform.position.z + 0.5f * transform.localScale.z - Enemy.transform.localScale.z / 2f);
        }
    }
}
