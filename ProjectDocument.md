# Project Progress Report

## Author Information
- Name: Jason Ma
- GitHub: [https://github.com/JasonBMa](https://github.com/JasonBMa)
## Categories Implemented
### Movement/Physics
#### Implemented player movement mechanics:
- `WASD` for directional movement.
- `Space/Shift` for Rolling.
    - Rolls in the direction of the current player input `(W,A,S,D)` have to be pressed with `Space/Shift`
    - Utilized Lerping to smooth out rolling speed.
- Helped create and augment collisions with Eric to fit the obstacles on the map accurately.
#### Implemented zombie movement mechanics:
Flocking/Seperation making the zombies not group up too close with each other, creating more of a threat and avoids stacking/overlaying sprites.

### Animation
- Added animator controllers, and setting up animations
    - Player, included animations of `Idle`, `Walking`, `Rolling`
    - Zombies, included animations of `Idle`, `Walking`, `Dying`
        - **Default**
        - **Archer**
        - **Wizard**: Contains a `Attack` animation
        - **Giant**
    - Power Ups Pick Ups
        - **Health**
        - **Damage**
        - **Speed**
        - **Range**
    - Also created a animation for pop up text indicating to the player what power is picked up and it's use.

### Map Design
Created starter map for testing meanwhile the Artist was developing our tileset, so we could start testing and implementing features of the game.
![](https://cdn.discordapp.com/attachments/1199392620959498400/1214754873099423844/Unity_amBOnGe27w.gif?ex=660cb8a2&is=65fa43a2&hm=cd5d2de7d84ba613995c300fcace50c9ead5be8207d4f2c135925538f2f0136b& =250x)

Later used Tileset provided by Team’s Artist (Nicholas Pham) to reconstruct a reimagined wasted version of the Quad in Davis, California.

### Game Logic
- Created Power Up Spawner that spawns a power up after every wave.
    - Generates a randomly selected power up `Health`, `Damage`, `Speed`, `Range`.
    - Plays a sound queue and a indicator of what the power up upgrade for the player.
- Created a Player States for the Player Controller, to keep track of what the player could and could not do within each state `Normal`, `Rolling`,`Stunned` ,`Dead`.
- Handled collision with Zombies
    - Altered the collision hit box to be accurate.
    - Insured that the zombies would only do damage when the zombie was alive and not in death animation.