using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPrefabs : MonoBehaviour
{
    public Transform rotater;
    public Transform circle;

    void Start()
    {
        course1();
        course2();
        course3();
        transform.position = transform.position + new Vector3(-22, 32.3f, -10);
        circle.transform.position = circle.transform.position + new Vector3(0, 0, 0);
        circle.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    void Update() {
        transform.Rotate(new Vector3(0, 8, 0) * Time.deltaTime);
    }

    void course1() {
        for (int i = 0; i < 9; i += 3) {
            var pickup = Instantiate(rotater, new Vector3(9.1f, 32.3f, -44 - i), Quaternion.identity);
            pickup.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        for (int i = 0; i < 20; i += 4) {
            var pickup = Instantiate(rotater, new Vector3(-2 - i, 32.3f, -55.75f), Quaternion.identity);
            pickup.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
    }

    void course2() {
        for (int i = 0; i < 9; i += 3) {
            var pickup = Instantiate(rotater, new Vector3(5 - i, 32.3f, -10), Quaternion.identity);
            pickup.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        for (var i = 0; i < 10; i++)      
        {
            var angle = i * Mathf.PI * 2 / 10;
            var pos = new Vector3 (Mathf.Cos(angle), 0, Mathf.Sin(angle)) * 2.3f;
            
            switch (i % 3) {                         
                case 0 :
                    var pickup1 = Instantiate(rotater, pos, Quaternion.identity, circle);
                    break;  

                case 1 :
                    var pickup2 = Instantiate(rotater, pos, Quaternion.identity, circle);
                    break;    

                case 2 :
                    var pickup3 = Instantiate(rotater, pos,  Quaternion.identity, circle);
                    break;
                }
        }
    }

    void course3() {
        for (int i = 0; i < 12; i += 4) {
            var pickup = Instantiate(rotater, new Vector3(-4 - i, 32.3f, -83), Quaternion.identity);
            pickup.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        for (int i = 0; i < 12; i += 4) {
            var pickup = Instantiate(rotater, new Vector3(-29 - i, 32.3f, -83), Quaternion.identity);
            pickup.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
    }
}
