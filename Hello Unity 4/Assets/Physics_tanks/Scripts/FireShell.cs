using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShell : MonoBehaviour
{
    static private float _delayReset = 0.2f;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _turret;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _turretBase;

    private float _speed = 15.0f;
    private float _rotSpeed = 5.0f;
    private float _moveSpeed = 1.0f;

    private float _delay = _delayReset;

    private void Update()
    {

        _delay -= Time.deltaTime;
        Vector3 direction = (_enemy.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _rotSpeed);
        float? angle = RotateTurret();

        if (angle != null && _delay <= 0.0f)
        {
            CreateBullet();
            _delay = _delayReset;
        }
        else
        {
            transform.Translate(0.0f, 0.0f, Time.deltaTime * _moveSpeed);
        }
    }

    private void CreateBullet() 
    {
        GameObject shell = Instantiate(_bullet, _turret.transform.position, _turret.transform.rotation);
        shell.GetComponent<Rigidbody>().velocity = _speed * _turretBase.forward;
    }

    private float? RotateTurret() 
    {
        float? angle = CalculateAngle(false);

        if (angle != null) 
        {
            _turretBase.localEulerAngles = new Vector3(360.0f - (float)angle, 0.0f, 0.0f);
        }
        return angle;
    }

    private float? CalculateAngle(bool low) 
    {
        Vector3 targetDir = _enemy.transform.position - this.transform.position;
        float y = targetDir.y;
        targetDir.y = 0.0f;
        float x = targetDir.magnitude - 1.0f;
        float gravity = 9.8f;
        float sSqr = _speed * _speed;
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if (underTheSqrRoot >= 0.0f) 
        {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;

            if (low)
            {
                return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg);
            }
            else
            {
                return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);
            }
        }
        else
        {
            return null;
        }
    }

    /*private Vector3 CalculateTrajectory() 
    {
        Vector3 p = _enemy.transform.position - this.transform.position;
        Vector3 v = _enemy.transform.forward * _enemy.GetComponent<Drive>().speed;
        float s = _bullet.GetComponent<MoveShell>().speed;

        float a = Vector3.Dot(v, v) - s * s;
        float b = Vector3.Dot(p, v);
        float c = Vector3.Dot(p, p);
        float d = b * b - a * c;

        if (d < 0.1f)
        {
            return Vector3.zero;
        }

        float sqrt = Mathf.Sqrt(d);
        float t1 = (-b - sqrt) / c;
        float t2 = (-b + sqrt) / c;

        float t = 0.0f;
        if (t1 < 0.0f && t2 < 0.0f)
        {
            return Vector3.zero;
        }
        else if (t1 < 0.0f)
        {
            t = t2;
        }
        else if (t2 < 0.0f)
        {
            t = t1;
        }
        else
        {
            t = Mathf.Max(new float[] { t1, t2 });
        }
        return t * p + v;
    }*/
}