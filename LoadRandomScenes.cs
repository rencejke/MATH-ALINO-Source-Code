using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadRandomScenes : MonoBehaviour
{
     //Fractions Easy
     private static List<int> loadedScenes = new List<int>();
     private static int lastLoadedSceneIndex = -1; 
     
    //Fractions Average
     private static List<int> loadedScenesFAverage = new List<int>();
     private static int lastLoadedSceneIndexFAverage = -1; 

      //Fractions Difficult
     private static List<int> loadedScenesFDiff = new List<int>();
     private static int lastLoadedSceneIndexFDiff = -1; 
     
     

    //place value
     private static List<int> loadedScenesPVEasy = new List<int>();
     private static int lastLoadedSceneIndexPVEasy = -1; 

     private static List<int> loadedScenesPVAvg = new List<int>();
     private static int lastLoadedSceneIndexPVAvg = -1; 

     private static List<int> loadedScenesPVDiff = new List<int>();
     private static int lastLoadedSceneIndexPVDiff = -1;


    public void loadRandomFractionScenesEasy()
    {
        List<int> sceneIndices = new List<int> { 57, 58, 59, 60, 61, 62, 63, 64, 65, 66};
        int specificSceneIndex = 109;
        
        if (loadedScenes.Count >= sceneIndices.Count)
        {
            
             SceneManager.LoadScene(specificSceneIndex);
            return;
        }

        sceneIndices.RemoveAll(index => loadedScenes.Contains(index));
        sceneIndices.Remove(lastLoadedSceneIndex); 

        int randomIndex = Random.Range(0, sceneIndices.Count);
        int sceneIndex = sceneIndices[randomIndex];

        loadedScenes.Add(sceneIndex);
        lastLoadedSceneIndex = sceneIndex; 
        SceneManager.LoadScene(sceneIndex);
    }

    public void loadRandomFractionScenesAverage()
    {
        List<int> sceneIndicesFAverage= new List<int> { 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76 };
        int specificSceneIndex2 = 109;
        
        if (loadedScenesFAverage.Count >= sceneIndicesFAverage.Count)
        {
            
             SceneManager.LoadScene(specificSceneIndex2);
            return;
        }

        sceneIndicesFAverage.RemoveAll(index => loadedScenesFAverage.Contains(index));
        sceneIndicesFAverage.Remove(lastLoadedSceneIndexFAverage); 

        int randomIndex = Random.Range(0, sceneIndicesFAverage.Count);
        int sceneIndex = sceneIndicesFAverage[randomIndex];

        loadedScenes.Add(sceneIndex);
        lastLoadedSceneIndexFAverage = sceneIndex; 
        SceneManager.LoadScene(sceneIndex);
    }

    public void loadRandomFractionScenesDifficult()
    {
        List<int> sceneIndicesDiff = new List<int> { 77, 78, 79, 80, 81, 82, 83, 84, 85, 86 };
        int specificSceneIndex3 = 109;
        
        if (loadedScenesFDiff.Count >= sceneIndicesDiff.Count)
        {
           
             SceneManager.LoadScene(specificSceneIndex3);
            return;
        }

        sceneIndicesDiff.RemoveAll(index => loadedScenesFDiff.Contains(index));
        sceneIndicesDiff.Remove(lastLoadedSceneIndexFDiff); 
        int randomIndex = Random.Range(0, sceneIndicesDiff.Count);
        int sceneIndex = sceneIndicesDiff[randomIndex];

        loadedScenes.Add(sceneIndex);
        lastLoadedSceneIndexFDiff = sceneIndex; 
        SceneManager.LoadScene(sceneIndex);
    }

//place value
    public void loadRandomPlaceValueScenesEasy()
{
    List<int> sceneIndicesPVEasy = new List<int> {17, 18, 19, 20, 21, 22, 23, 24, 25, 26};
    int specificSceneIndex4 = 109;

    if (loadedScenesPVEasy.Count >= sceneIndicesPVEasy.Count)
    {
        
        SceneManager.LoadScene(specificSceneIndex4);
        return;
    }

    sceneIndicesPVEasy.RemoveAll(index => loadedScenesPVEasy.Contains(index));
    sceneIndicesPVEasy.Remove(lastLoadedSceneIndexPVEasy); 

   
    if (sceneIndicesPVEasy.Count == 0)
    {
        Debug.Log("No more scenes to load.");
        return;
    }

    int randomIndex = Random.Range(0, sceneIndicesPVEasy.Count);
    int sceneIndex = sceneIndicesPVEasy[randomIndex];

    loadedScenesPVEasy.Add(sceneIndex);
    lastLoadedSceneIndexPVEasy = sceneIndex; 
    SceneManager.LoadScene(sceneIndex);
}


    public void loadRandomPlaceValueScenesAverage()
{
    List<int> sceneIndicesPVAvg = new List<int> {27, 28, 29, 30, 31, 32, 33, 34, 35, 36};
    int specificSceneIndex5 = 109;

    if (loadedScenesPVAvg.Count >= sceneIndicesPVAvg.Count)
    {
        
        SceneManager.LoadScene(specificSceneIndex5);
        return;
    }

    sceneIndicesPVAvg.RemoveAll(index => loadedScenesPVAvg.Contains(index));
    sceneIndicesPVAvg.Remove(lastLoadedSceneIndexPVAvg); 
        if (sceneIndicesPVAvg.Count == 0)
    {
        Debug.Log("No more scenes to load.");
        return;
    }

    int randomIndex = Random.Range(0, sceneIndicesPVAvg.Count);
    int sceneIndex = sceneIndicesPVAvg[randomIndex];

    loadedScenesPVAvg.Add(sceneIndex);
    lastLoadedSceneIndexPVAvg = sceneIndex; 
    SceneManager.LoadScene(sceneIndex);
}


     public void loadRandomPlaceValueScenesDiff() {
    List<int> sceneIndicesPVDiff = new List<int> {37, 38, 39, 40, 41, 42, 43, 44, 45, 46};
    int specificSceneIndex6 = 109;

    if (loadedScenesPVDiff.Count >= sceneIndicesPVDiff.Count)
    {
        // All scenes have been loaded, show the game over panel
        SceneManager.LoadScene(specificSceneIndex6);
        return;
    }

    sceneIndicesPVDiff.RemoveAll(index => loadedScenesPVDiff.Contains(index));
    sceneIndicesPVDiff.Remove(lastLoadedSceneIndexPVDiff); 

   
    if (sceneIndicesPVDiff.Count == 0)
    {
        Debug.Log("No more scenes to load.");
        return;
    }

    int randomIndex = Random.Range(0, sceneIndicesPVDiff.Count);
    int sceneIndex = sceneIndicesPVDiff[randomIndex];

    loadedScenesPVDiff.Add(sceneIndex);
    lastLoadedSceneIndexPVDiff = sceneIndex;
    SceneManager.LoadScene(sceneIndex);
}


}
