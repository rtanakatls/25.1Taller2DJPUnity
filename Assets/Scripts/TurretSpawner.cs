using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;
    private Camera cam;

    private void Start()
    {
        cam=GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = cam.ScreenToWorldPoint(Input.mousePosition);
            GameObject obj=Instantiate(turretPrefab);
            obj.transform.position = position;  
        }

    }

}
