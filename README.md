
# Endless Runner Game

This is a Unity-based **Endless Runner** game where a player controls a character running through an endless series of sections. The goal is to avoid obstacles, collect coins, and achieve the highest possible score. If the character collides with obstacles such as rocks or trees, the game ends.

![EndlessRunner](https://github.com/user-attachments/assets/5d64777b-741b-49c0-ae71-8ae29cd0b8fe)

---

## Features
- [x] Endless Runner Gameplay.
- [x] Automatic Forward Movement.
- [x] Physics-Based Collision.
- [x] Side-to-Side Movement
- [x] Infinite Level Generation
- [x] Automatic Cleanup
- [x] Coin Collection and Scoring
- [x] High Score Tracking
- [x] Game Over Screen
- [x] Dynamic Obstacles
- [x] Engaging Visual Effects 
### Gameplay Mechanics
- **Running and Movement**:
  - The player moves forward automatically.
  - Horizontal movement is controlled using `A` and `D` keys or arrow keys.
  - Movement is restricted to predefined bounds to prevent the player from going out of the play area.
- **Obstacle Interaction**:
  - Obstacles include rocks and trees with active `isTrigger` components.
  - On collision, the player is knocked backward, the game ends, and the `Game Over` screen is displayed.
- **Infinite Sections**:
  - Sections are dynamically generated at runtime every 5 seconds using `Generate.cs`.
  - Old sections are removed to optimize performance via a delayed batch deletion mechanism.

### Visuals and Feedback
- **Rotating Coins**:
  - Coins rotate for a visually engaging appearance.
  - Coins add to the player’s score when collected.
- **Game Over Screen**:
  - Displays the current score and provides a "Try Again" button for restarting the game.
- **High Score System**:
  - Tracks and displays the highest score achieved.
  - Uses `PlayerPrefs` to save the high score persistently.

---

## Code Overview

### Play Area Bounds
The play area is defined with left and right boundaries in `Environment.cs`:

```csharp
public class Environment : MonoBehaviour
{
    public static float LeftSide = -14.5f;
    public static float RightSide = 14.5f;

    void Update()
    {
        internalLeft = LeftSide;
        internalRight = RightSide;
    }
}
```

### Infinite Section Generation
New sections are generated dynamically in `Generate.cs`. Old sections are stored in a list and deleted in batches to avoid performance issues.

```csharp
IEnumerator GenerateSection()
{
    secNum = Random.Range(0, 1);
    GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
    zPos += 59;

    destroyScript.AddSectionForDeletion(newSection);

    yield return new WaitForSeconds(5);
    creatingSection = false;
}
```

### Section Deletion
Sections are deleted in `Destroy.cs` using a delay to prevent simultaneous removal of multiple objects:

```csharp
IEnumerator DeleteSectionsInBatches()
{
    while (sectionsToDelete.Count > 0)
    {
        if (ObstacleCollision.isGameOver)
            yield break; 

        int countToDelete = Mathf.Min(deleteBatchSize, sectionsToDelete.Count);
        for (int i = 0; i < countToDelete; i++)
        {
            GameObject sectionToDelete = sectionsToDelete[0];
            sectionsToDelete.RemoveAt(0);
            sectionToDelete.SetActive(false);
            yield return new WaitForSeconds(2f);  
            Destroy(sectionToDelete); 
        }

        yield return new WaitForSeconds(delayBetweenDeletes); 
    }
}
```

### Player Movement
Horizontal player movement is controlled in `PlayerMove.cs`:

```csharp
void Update()
{
    transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    {
        if (this.gameObject.transform.position.x > Environment.LeftSide)
        {
            transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed);
        }
    }

    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
        if (this.gameObject.transform.position.x < Environment.RightSide)
        {
            transform.Translate(Vector3.right * Time.deltaTime * LeftRightSpeed);
        }
    }
}
```

### Collision and Game Over Handling
On collision, the player is knocked back, and the `Game Over` screen is displayed:

```csharp
void OnTriggerEnter(Collider other)
{
    StartCoroutine(EndGameSequence());
}

IEnumerator EndGameSequence()
{
    this.gameObject.GetComponent<BoxCollider>().enabled = false;
    thePlayer.GetComponent<PlayerMove>().enabled = false;
    charmodel.GetComponent<Animator>().Play("Stumble Backwards");
    yield return new WaitForSeconds(1);

    endscreen.SetActive(true);
    isGameOver = true;

    yield return new WaitForSeconds(1);
}
```

### Coin Collection and Scoring
Coins are collected to increase the score. High scores are updated if surpassed:

```csharp
void Update()
{
    coinCountDisplay.GetComponent<Text>().text = coinCount.ToString();

    if (coinCount > highScore)
    {
        highScore = coinCount;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    highScoreDisplay.GetComponent<Text>().text = highScore.ToString();
}
```

### Restarting the Game
The "Try Again" button restarts the game:

```csharp
public void RestartGame()
{
    CollectableControl.coinCount = 0;
    isGameOver = false;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
```

---

## Installation and Setup
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Open the project in Unity.
3. Play the game in the Unity Editor or build it for your preferred platform.

---


