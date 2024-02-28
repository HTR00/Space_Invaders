using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour, IPointerClickHandler
{
    public SceneTransition sceneTransition;

    void Start()
    {
        if (sceneTransition == null)
        {
            sceneTransition = FindObjectOfType<SceneTransition>();
            if (sceneTransition == null)
            {
                Debug.LogError("SceneTransitionManager não encontrado. Certifique-se de ter uma referência ou que ele está na cena.");
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (sceneTransition != null)
        {
            sceneTransition.LoadGameScene();
        }
        else
        {
            Debug.LogError("SceneTransitionManager não definido no botão 'Play'.");
        }
    }

}
