using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialGameSceneTab : MonoBehaviour
{
    public List<GameObject> checkMarkList = new List<GameObject>();
    [SerializeField] private GameObject tutorialWindow;

    [SerializeField] private TutorialGameSceneTab nextTutorial;
    [SerializeField] private List<TutorialGameSceneTab> beforTutorial = new List<TutorialGameSceneTab>();
    // Start is called before the first frame update
    void Start()
    {
        //チェックマークを非表示
        foreach(var checkIcon in checkMarkList)
        {
            checkIcon.SetActive(false);
        }
        //チュートリアルウィンドウを表示
        if(tutorialWindow != null)tutorialWindow.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// チェックマークを表示する
    /// </summary>
    /// <param name="index">チェックマークのインデックス</param>
    public void SetMark(int index)
    {
        if(this.gameObject.activeSelf == false) return;
        checkMarkList[index].SetActive(true);

        //もし全てクリアしたらウィンドウを非表示にする
        bool _isAllCheck = true;
        foreach(var checkIcon in checkMarkList)
        {
            if(!checkIcon.activeSelf)
            {
                _isAllCheck = false;
            }
        }
        if(_isAllCheck)
        {
            tutorialWindow.SetActive(false);
            NextTutorial();
        }
    }
    private void NextTutorial()
    {
        if (nextTutorial == null) return;
        nextTutorial.tutorialWindow.SetActive(true);
    }
}
