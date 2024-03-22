# Project Progress Report

## Author Information
- Name: Jason Ma
- GitHub: [https://github.com/JasonBMa](https://github.com/JasonBMa)
## Categories Implemented
### Movement/Physics
- Implemented player movement mechanics:
    - Added basic player movement controls.
        - WASD for directional
        - Space/Shift for Rolling
    - Implemented collision detection for player movement.
- Implemented zombie movement mechanics:
    - Flocking/Seperation causes the zombies to not group up too close with each other, creating more of a threat.

### Animation
- Added animator controllers, and setting up animations
    - Player
    - Zombies
        - **Default**
        - **Archer**
        - **Wizard**: Contains a attack animation
        - **Giant**
    - Power Ups Pick Ups
        - **Health**
        - **Damage**
        - **Speed**
        - **Range**
    - Also created a animation for pop up text indicating to the player what power is picked up and it's use.

### Map Design
Created starter map for testing meanwhile the Artist was developing our tileset, so we could start testing and implementing features of the game.

Later used Tileset provided by Team’s Artist (Nicholas Pham) to reconstruct a reimagined wasted version of the Quad in Davis, California.

### Game Logic
- Created power up spawner