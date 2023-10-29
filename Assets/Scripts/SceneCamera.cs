using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        //assign the camere to folow the player on start on each scene/stage
        cinemachineVirtualCamera.Follow = NewPlayer.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
