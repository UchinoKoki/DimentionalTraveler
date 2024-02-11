using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//シーン遷移管理
//演出完了後に呼び出し。シーン遷移を行う
public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    AsyncOperation asyncOperation;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    //シーン遷移(AsyncOperationをfalseで止める)
    public void LoadScene(string sceneName)
    {
        asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
    }
    //フェード終了後にこれがLoad待ちの場合はここでシーン遷移を行う
    public void OnCompleteFade()
    {
        if(asyncOperation == null) return;
        asyncOperation.allowSceneActivation = true;
        asyncOperation = null;
    }
}
