using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject MyProjectile;
    [SerializeField] int _numberOfProjectilesPerSecond = 4;
    private float _timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1f / (float)_numberOfProjectilesPerSecond)
        {
            GameObject _projectileInstance = Instantiate(MyProjectile);
            _projectileInstance.transform.position = transform.position;
            _projectileInstance.transform.rotation = transform.rotation;
            _timer = 0;
        }
    }
}
