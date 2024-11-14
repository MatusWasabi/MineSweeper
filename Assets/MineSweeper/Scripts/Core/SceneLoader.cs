
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;


public class SceneLoader : MonoBehaviour
{
    // Reference to scene in the project without having to hard-coded string or number
    // [SerializeField] private SceneAsset sceneToLoad; This can be used with editor-runtime only. Not Build-runtime.

    [SerializeField] private AssetReference sceneReference;
    public void LoadScene()
    {
        if (sceneReference != null)
        {
            // Load scene asynchronously via Addressables
            sceneReference.LoadSceneAsync(LoadSceneMode.Single);
        }
    }
}
