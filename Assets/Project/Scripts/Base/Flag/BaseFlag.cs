using UnityEngine;

public class BaseFlag : MonoBehaviour
{
    private GameObject _backlight;
    private GameObject _flag;

    private void Start()
    {
        _flag = GetComponentInChildren<Flag>().gameObject;
        _backlight = GetComponentInChildren<Backlight>().gameObject;

        _backlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        _backlight.SetActive(true);
    }

    private void Update()
    {
        if (_backlight.activeSelf)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _flag.transform.position = hit.point;

                if (Input.GetMouseButtonDown(1))
                {
                    _backlight.SetActive(false);
                }
            }
        }
    }

    //private void InstantiateFlag(Vector3 position)
    //{
    //    GameObject newFlag = Instantiate(_flag, position, Quaternion.identity);
    //}
}