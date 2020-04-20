using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField]
    GameObject[] MenuObjects;
    [SerializeField]
    CanvasGroup canvasGroup;
    [SerializeField]
    float EaseSpeed;
    [SerializeField]
    bool isEasing = false;

    bool IsinTheme;

    [SerializeField]
    bool MenuEnabled;

    [SerializeField]
    int currentMenuState;

    [SerializeField]
    Game game;

    void Start() {
        IsinTheme = true;
        MenuEnabled = true;
        game.PauseGame(true);
        currentMenuState = 0;
        isEasing = false;
        canvasGroup = this.GetComponent<CanvasGroup>();
        SetMenu(5);
        StartCoroutine(MainTimer());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (MenuEnabled && !IsinTheme) {
                StartCoroutine(Ease(0));
            }
            else if (!MenuEnabled) {
                SetMenu(1);
                game.PauseGame(true);
                StartCoroutine(Ease(1));
            }
        }
    }

    public void SetMenu(int menuType) {
        for (uint i = 0; i < MenuObjects.Length; i++) {
            MenuObjects[i].gameObject.SetActive(false);
        }
        currentMenuState = menuType;
        MenuObjects[menuType].gameObject.SetActive(true);
    }

    void EaseMenuIn(int menuType) {
        if (!isEasing) {
            StartCoroutine(Ease(1));
        }
    }

    public void EaseMenuOut() {
        if (!isEasing) {
            StartCoroutine(Ease(0));
        }
    }

    IEnumerator Ease(int target) {
        isEasing = true;
        while (Mathf.Abs(canvasGroup.alpha - target) > 0.01f ) {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, target, Time.deltaTime * EaseSpeed);
            yield return null;
        }
        isEasing = false;
        if (MenuEnabled) {
            game.PauseGame(false);
            MenuEnabled = false;
        }

        else if (!MenuEnabled) {
            MenuEnabled = true;
        }
        canvasGroup.alpha = target;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void SkipTutorial() {
        IsinTheme = false;
    }

    IEnumerator MainTimer() {
        SetMenu(5);
        yield return new WaitForSeconds(5);
        SetMenu(0);
    }
}
