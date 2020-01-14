using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    [SerializeField] private Camera camera;
    [SerializeField] private GameObject beginObject;
    [SerializeField] private Transform beginPos;
    private sceneManager sm;

    // Start is called before the first frame update
    void Start()
    {
        beginPos = beginObject.transform;
        Scene sceneLoaded = SceneManager.GetActiveScene();
        if (sceneLoaded.buildIndex == 1)
        {
            loadNewLevelEffect();
        }
        loadNewLevelEffect();
    }

    // Update is called once per frame
    void Update()
    {
        if(beginPos != beginObject.transform)
        {
            resetCullingMask();
        }
    }

    public void loadNewLevelEffect()
    {
            camera.cullingMask = 9 << 9;
    }

    public void resetCullingMask()
    {
        camera.cullingMask = -1;
    }
}
