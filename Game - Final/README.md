# Mad Driver Game

A Unity 3D endless runner/driving game where players navigate through a dangerous road filled with obstacles to reach the finish line.

## 🎮 Game Overview

**Mad Driver** is an action-packed 3D driving game built in Unity. Players control a vehicle on a road filled with randomly spawned obstacles and must reach the win line without hitting any items to achieve victory.

### 🎯 Game Objective
- Navigate your vehicle from start to finish line
- Avoid all obstacles/items on the road
- Reach the win line to win the game
- Hitting any obstacle results in game over

## 🎮 Controls

| Input | Action |
|-------|--------|
| **WASD** / **Arrow Keys** | Move vehicle |
| **W/S** or **Up/Down** | Forward/Backward movement |
| **A/D** or **Left/Right** | Turn left/right |
| **Space** | Jump (in some game modes) |
| **Left Shift** | Sprint/Boost |

*Supports multiple input methods: Keyboard, Gamepad, and XR Controllers*

## 🏗️ Game Architecture

### Core Scripts

#### 1. **PlayerController.cs**
- Handles vehicle movement and rotation
- Configurable speed and turn speed parameters
- Uses Unity's Input system for smooth controls
- Forward movement with steering mechanics

```csharp
public float speed = 20;        // Forward movement speed
public float turnSpeed = 10;    // Turning speed
```

#### 2. **SpawController.cs**
- Manages random obstacle spawning across the road
- Spawns all items at game start for immediate road population
- Configurable spawn area and item management

**Key Features:**
- **Spawn Area**: X(-8 to 9), Z(20 to 160), Height(1)
- **Max Items**: 20 obstacles simultaneously
- **Auto-cleanup**: Items destroyed after 30 seconds
- **Random Distribution**: Even spread across road width

#### 3. **hitHandler.cs**
- Collision detection system
- Win/lose condition management
- Game state control

**Collision System:**
- **Distance-based detection**: Collision when player within 2 units of obstacle
- **Unity Trigger system**: Alternative collision method using built-in physics
- **Win condition**: Player reaches win line (Z-position based)
- **Death condition**: Player hits any spawned obstacle

#### 4. **FollowPlayer.cs**
- Third-person camera system
- Maintains consistent offset from player vehicle
- Smooth camera following with configurable offset

**Camera Settings:**
```csharp
private Vector3 offset = new Vector3(0, 10, -10); // X, Y, Z offset
```

## 🎮 Game Flow

1. **Game Start**
   - All obstacles spawn instantly across the road
   - Player spawns at starting position
   - Camera follows player vehicle

2. **Gameplay**
   - Player navigates through obstacle field
   - Real-time collision detection
   - Continuous camera following

3. **Win Condition**
   - Player reaches win line without hitting obstacles
   - Game pauses and displays victory
   - Auto-restart after 3 seconds

4. **Lose Condition**
   - Player hits any obstacle
   - Game pauses and shows game over
   - Auto-restart after 3 seconds

## 🛠️ Technical Features

### Unity Systems Used
- **Input System**: Modern Unity Input System for cross-platform controls
- **Physics**: Rigidbody-based movement and collision detection
- **Coroutines**: For timed events and game state management
- **Scene Management**: Automatic scene reloading for restart functionality

### Performance Optimizations
- **Object Pooling**: Items auto-destroy to prevent memory leaks
- **Efficient Collision**: Dual collision detection methods for reliability
- **Optimized Spawning**: All items spawn at start to avoid runtime performance hits

### Multi-Platform Support
- **Input Methods**: Keyboard, Gamepad, XR Controllers
- **Cross-platform**: Built with Unity's universal input system

## 🎨 Game Design

### Visual Style
- 3D environment with road-based gameplay
- Third-person perspective with following camera
- Obstacle-based challenge design

### Difficulty Curve
- **Static Challenge**: All obstacles present from start
- **Spatial Challenge**: 140-unit road length (Z: 20-160)
- **Precision Required**: 2-unit collision detection radius

## 🔧 Setup Instructions

### Prerequisites
- Unity 2022.3+ (Unity 6000.1.11f1 recommended)
- Input System package
- 3D project template

### Installation
1. Clone/download the project
2. Open in Unity Hub
3. Ensure Input System package is installed
4. Setup required tags: "SpawnedItem"
5. Assign prefabs to SpawnController
6. Configure camera and player references

### Configuration
1. **SpawnController**: Assign obstacle prefabs to `itemPrefabs[]` array
2. **hitHandler**: Assign Player and Win Line GameObjects
3. **FollowPlayer**: Assign Player GameObject reference
4. **Camera Setup**: Attach FollowPlayer script to main camera

## 🎯 Game Metrics

- **Road Length**: 140 units
- **Road Width**: 17 units (-8 to +9)
- **Max Obstacles**: 20 simultaneous
- **Collision Range**: 2 units
- **Vehicle Speed**: 20 units/second (configurable)
- **Turn Speed**: 10 degrees/second (configurable)

## 🏆 Game Variants

The project includes multiple game prototypes:
- **Mad Driver** (Prototype 1): Main driving/obstacle avoidance game
- **Fly Like A Bird** (Challenge 3): Flying mechanics with vertical movement
- **I'm Sumo** (Prototype 4): Arena-based sumo wrestling with powerups

## 🐛 Known Features
- Automatic game restart on win/lose
- Real-time obstacle tracking
- Smooth camera following
- Cross-platform input support
- Efficient memory management

## 👨‍💻 Development Info

**Engine**: Unity 6000.1.11f1  
**Platform**: Cross-platform (Windows, Mac, Mobile)  
**Scripts**: C# with Unity MonoBehaviour  
**Input**: Unity Input System  
**Physics**: Unity 3D Physics System  

---

*This game is part of Game Design & Development CSX4515 coursework.*