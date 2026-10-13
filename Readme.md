# TressureCastle

TressureCastle is a 2D Unity platformer adventure set in a treasure-hunting castle environment. The player explores levels, climbs ladders, avoids hazards, defeats enemies, and collects coins while progressing through the game.

## Overview

This project was built as a small action-platformer prototype with:

- Side-scrolling movement and jumping
- Ladder climbing mechanics
- Coin collection and score tracking
- Health and death states
- Enemy and hazard interaction
- Pause and restart flow
- Multi-scene progression between gameplay areas

## Gameplay

The player controls a character through castle-themed levels, collecting coins and surviving hazards such as water, enemies, and falling damage. Some rooms require climbing ladders and moving carefully through dangerous sections.

## Tech Stack

- Unity 2D
- Universal Render Pipeline (URP)
- Unity Input System
- C# scripting
- Unity Scene and UI system

## Project Structure

- `Assets/` – game assets, scenes, prefabs, and scripts
- `Assets/Scripts/` – gameplay logic and UI management
- `Packages/` – Unity package manifest and dependency metadata
- `ProjectSettings/` – Unity project configuration

Core gameplay scripts include:

- `PlayerMovement.cs` – movement, jumping, climbing, and trigger detection
- `EnemyScript.cs` – enemy movement and direction changes
- `HealthManager.cs` – health handling and death logic
- `UiManager.cs` – pause, resume, and restart menu behavior
- `CoinManager.cs` and `CoinHandler.cs` – coin collection and tracking

## Getting Started

### Prerequisites

- Unity Hub
- Unity 2022.3 LTS or a compatible Unity version

### Run the project

1. Open Unity Hub.
2. Click Open and select this project folder: `TressureCastle`.
3. Let Unity import the project and resolve packages.
4. Open the main scene from the `Assets` folder.
5. Press Play in the Unity Editor to test the game.

## Controls

- Move: `A / D` or `Left / Right Arrow`
- Jump: `Space`
- Climb ladders: `W / S` or `Up / Down Arrow`
- Pause: `Esc` or the in-game pause button

## Notes

This project is a lightweight game prototype and may still contain placeholder behavior or unfinished polish. It is suitable for learning, experimentation, and further level/gameplay expansion.

## License

This project does not currently specify a license. If you plan to distribute or reuse it, add an appropriate open-source or commercial license before publishing.
