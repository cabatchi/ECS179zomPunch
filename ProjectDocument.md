# Project Progress Report

## Authors Information

- Name: Jason Ma
- GitHub: [https://github.com/JasonBMa](https://github.com/JasonBMa)
- Name: Eric Barron
- GitHub: [https://github.com/ericbarron329](https://github.com/ericbarron329)
- Name: -
- GitHub: [-](https://github.com/JasonBMa)
- Name: Keith Low
- GitHub: https://github.com/keith-loww

## Game Logic (Eric Barron)

### Jason's Implementation in Game Logic

- Created Power Up Spawner that spawns a power up after every wave.
  - Generates a randomly selected power up `Health`, `Damage`, `Speed`, `Range`.
  - Plays a sound queue and a indicator of what the power up upgrade for the player.
- `PlayerController parts` Created a Player States for the Player Controller, to keep track of what the player could and could not do within each state `Normal`, `Rolling`,`Stunned` ,`Dead`.
- `ZombieController parts` Handled collision with Zombies
  - Altered the collision hit box to be accurate.
  - Insured that the zombies would only do damage when the zombie was alive and not in death animation.

### Eric's Implementation

My role was responsible for creating the core mechanics of the game. From the start, our team wanted to create a top-down zombie survival game. We started with the regular zombie and soon branched out to have different types of zombies chasing the player. Our approach was to have a dynamic range of mobs the player could fight.

The magic and archer zombies have unique features in approaching the player. They will chase the player until they get too close, then will start to back up. This was added to give a realistic feel as the ranged mobs would want to keep their distance from the player.

Features added:

The core mechanic of the game is centered around zombies. There are multiple types of zombies that spawn from the same regions. Regular zombies run at the player while range-based zombies will back up if the player gets too close.

[Zombie Spawnwer](https://github.com/cabatchi/ECS179zomPunch/commit/7dcbfec3710a64839ab3d0a966df419287858418)

[Regular Zombie](https://github.com/cabatchi/ECS179zomPunch/commit/7dcbfec3710a64839ab3d0a966df419287858418#diff-e89292b67e46d1f25eaeb808ae9e86eb3a191485c6ada3a9d4da5900e2edbf88)

[Archer Zombie / Magic Zombie](https://github.com/cabatchi/ECS179zomPunch/commit/4790c17b77de2470567769c2ff9af91461b74b44)

[Giant Zombie](https://github.com/cabatchi/ECS179zomPunch/commit/bbf303701e1e2e83403fa7b2c4654a0ac9663cc9)

[Zombie Collisions](https://github.com/cabatchi/ECS179zomPunch/commit/26df3f106e954a96dd8f937b5cc8008450c0458d)

Player and enemy attacks were created to add a PvE system into the game. Centered around projectiles, both the player and the enemy can shoot at each other. Homing bullets and projectiles can damage the player while the player can shoot back with a punch animation. The bullet script has a fixed position around the player so the player can point and shoot in their desired direction. Furthermore, scripts like the homing bullet are tailored to lock on to the player and chase them for a set amount of time.

[BulletScript / PlayerAttack](https://github.com/cabatchi/ECS179zomPunch/commit/25ddafff892854b014f7a91a2bf5423192b39c35)

[EnemyProjectile / HomingBullet](https://github.com/cabatchi/ECS179zomPunch/commit/4790c17b77de2470567769c2ff9af91461b74b44#diff-df9197a964300c0605722f384d4791007ce1a6a82b8eace72f9f260132185610)

Powerups and Item shop features were implemented to give the player a replayable aspect of the game. Upgrading and increasing stats make the game more enjoyable as the player can get to high rounds.

[ItemShop](https://github.com/cabatchi/ECS179zomPunch/commit/2d5de45e70f8d4a8eb42f60e3f7583072215dd55)

[PouwerupEffect / HealthBuff](https://github.com/cabatchi/ECS179zomPunch/commit/41b52287a8e4c9bcdb3d73896ef2a057e2834659)

[DamageBuff](https://github.com/cabatchi/ECS179zomPunch/commit/e85ecf236ae526957ac8e1b558745e3b1424ff28)

[RangeBuff](https://github.com/cabatchi/ECS179zomPunch/commit/d953fce85a49cb0a437154523746d9b7daf837d8)

## Movement/Physics (Jason Ma with help from Eric Barron)

### Implemented player movement mechanics:

- `WASD` for directional movement.
- `Space/Shift` for Rolling.
  - Rolls in the direction of the current player input `(W,A,S,D)` have to be pressed with `Space/Shift`
  - Utilized Lerping to smooth out rolling speed.
  - Has a timer incase the player gets stuck in the `Rolling` state

### Implemented zombie movement mechanics:

Flocking/Seperation making the zombies not group up too close with each other, creating more of a threat and avoids stacking/overlaying sprites.

### Collision

- Eric started and designed the collision between the sprites and map.
- Eric checked for out of bound rolling, and insured player didn't roll out of the map.
- Jason moved and tweaked map later on based off of bugs and issues that arose.

## Animations and Visuals (Nicholas Phan and Jason Ma)

In this project, went with the theme of "Rolling with the punches" and decided to create a game with two main mechanics: `Punching` and `Rolling`.

_The Normal Zombies: _ <br>
![This is an alt text.](https://img.itch.zone/aW1hZ2UvMzA2MjY5LzE1MDMxNDEuZ2lm/347x500/by419N.gif "Hehe run away bro")

_The Giant:_ <br>
![This is an alt text.](https://cdn.discordapp.com/attachments/591185804630687744/1220611084084314172/image.png?ex=660f91a8&is=65fd1ca8&hm=471d68e63146af2cb504350f229114b637a8625a3be5da71041efa79db0192c6& "It's Jam I swear")

_The Archer:_ <br>
![This is an alt text.](https://media.discordapp.net/attachments/1199392620959498400/1219580920244207626/libresprite_bGbeESyIwG.png?ex=660bd23e&is=65f95d3e&hm=52cf1e6a003a6d7a419c3260962ebad935c8898195b8fddbe8e7c88d6bb18662&=&format=webp&quality=lossless "Robin your Pockets bro")

_The Mage:_ <br>
![This is an alt text.](https://media.discordapp.net/attachments/1199392620959498400/1219572242082693211/libresprite_ShUi6JugLx.png?ex=660bca29&is=65f95529&hm=2ff0894de424cac7619015013a1f89fc5dab6e928537d79a12b3c760524ed959&=&format=webp&quality=lossless "Magic Missile!")

We took the original [asset](https://lhteam.itch.io/zombie-toast) and edited the sprite itself to create variations of what we want in terms of enemies, Jason was the one that designed the Enemy Variants.

## Art Direction (Nicholas Phan)

I designed and created the TileMap that we would use for our game, as well as Player sprite and powerups. I started by creating some test sprites in 16x16. The choice was essentially creating a 2D pixel game and I ended up just making it 16x16 and held to it.

The Test Sprites I made are shown here, I went with a simple stick figure design so that way the team would be able to have some visuals to work with while they programmed the general gameplay.

Here I created a simple set of animations regarding the four main characteristics of the player: Walking, Rolling, Punching, and Idle.

| Idle                                                                                                                                                                                                                                   | Walking                                                                                                                                                                                                                                 | Punching                                                                                                                                                                                                                                          | Rolling                                                                                                                                                                                                                                   |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Insert Idle Here.](https://cdn.discordapp.com/attachments/1199392620959498400/1213245915553472532/TestSprite.gif?ex=66073b4f&is=65f4c64f&hm=5bda9a6bedb8cb0480aeebeb2bccb7ba4f523cd62bb95e99dc5356bb68237769& "Haha He's Standing!") | ![Insert Walk Here.](https://cdn.discordapp.com/attachments/1199392620959498400/1213256378836058192/TestSpriteWalk.gif?ex=6607450d&is=65f4d00d&hm=5916cd53584028216371ad20feac03c2370ceb54f37a0aa5c1ab0650285b3404& "Look at em Walk!") | ![Insert Idle Here.](https://cdn.discordapp.com/attachments/1199392620959498400/1213245987796033637/TestAttackSprite.gif?ex=66073b60&is=65f4c660&hm=999735d415d547cd8c7d5cc7fa03b98e5ee72a923f24424f224344c3c7515176& "That punch is insane fr!") | ![Insert Rolling Here.](https://cdn.discordapp.com/attachments/1199392620959498400/1213256033720602644/TestSpriteRoll.gif?ex=660744bb&is=65f4cfbb&hm=59058422f526077889fa20f952c5c734ed450c712b80eadd266e484218e5f34f& "He's on a roll!") |

We had then took a different approach: The punching. We had decided to create the game to where we could actually aim the punches just like how you would in a pixel based shooter, kinda like [Enter The Gungeon](https://store.steampowered.com/app/311690/Enter_the_Gungeon/). After finalizing our aesthetics and game ideas, I had then changed the sprites to it's finalized design, and ended up not needing to create an attacking animation. Note: all of this was made possible using the online free tool: [Piskel](https://www.piskelapp.com/)!

| Idle                                                                                                                                                                                                                                   | Walking                                                                                                                                                                                                                                  | Rolling                                                                                                                                                                                                                                 |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Insert Idle Here.](https://cdn.discordapp.com/attachments/1199392620959498400/1216537096903196712/New_Piskel.gif?ex=6609f9f6&is=65f784f6&hm=4097b47dd75a9066f522c8abedde5d76e15b4d442806e2b1392bea85d795f8af& "Haha He's Standing!") | ![Insert Walk Here.](https://cdn.discordapp.com/attachments/1199392620959498400/1216551856797384785/ZomPunchWalking.gif?ex=660a07b5&is=65f792b5&hm=fd9e0dcd883ae23345e209024e11ae57561eee67729dd254c7f8a4bd9b6b1db1& "Look at em Walk!") | ![Insert Rolling Here.](https://cdn.discordapp.com/attachments/1199392620959498400/1218330424460447934/ZomPunchRoll.gif?ex=660745a0&is=65f4d0a0&hm=43dcf7a2b18cf4e1cf62922e8b5e1734d10f4de80e61d9fe1952c360f5d90a2f& "He's on a roll!") |

### Map Design (Nicholas Phan and Jason Ma)

For Map Design, we wanted to use the quad as our main map to where we would hold the player to survive in. I had some previously made tiles made for a previous personal project and was able to reuse the assets there. I also had to draw a couple other new things, such as Tables to be borders for the player to not pass over, miscellaneous trash and blood(Jam) on the floor, and had also created the legendary blue hammocks for near the quad for peoeple. I had used a free software known as [Tiled](https://www.mapeditor.org/) to create the tile map, however, there were size errors with my created map (Resolution errors, way too small). Luckily, Jason was able to redesign the map with the given tile map, and created this beautiful design of a post apocolyptic quad:

Original map design from Nick:

![Nick's Map.](https://cdn.discordapp.com/attachments/1199392620959498400/1214826893283426384/QuadMapDraft.png?ex=660cfbb5&is=65fa86b5&hm=631e84b25a13a069695134493c672aa1ebd33e87cfe7ec9b56bc5e3a3fa89bfb& "Not bad")

Jason's design:

![Jason's Map.](https://cdn.discordapp.com/attachments/1199392620959498400/1219529531279544400/Unity_kSid6h3MxI.gif?ex=660ba262&is=65f92d62&hm=70fbb0b71a44016c79dc3fec25bc5b9dd56e038b96019f175599f42e76d4e6fa& "Mona Lisa")

Here is my original tileset that I had made from scratch:<br>
![Nick's TileSet.](https://cdn.discordapp.com/attachments/1199392620959498400/1219542158260961290/Tilemap.png?ex=660bae24&is=65f93924&hm=c2981df351ef97f796ec61ea03cbb0fd76ebf58e6898548d877744e2bad1aa23& "Not Bad for a first tile set")

Jason created starter map for testing meanwhile the Nick was developing our tileset, so we could start testing and implementing features of the game.
![beginnings.](https://cdn.discordapp.com/attachments/1199392620959498400/1214754873099423844/Unity_amBOnGe27w.gif?ex=660cb8a2&is=65fa43a2&hm=cd5d2de7d84ba613995c300fcace50c9ead5be8207d4f2c135925538f2f0136b&=1x1 "implementation")

Along with this, we had also used [“Clockwork Raven – Additional Art Assets”](https://clockworkraven.itch.io/raven-fantasy-pixel-art-tileset-green-forest) to use along our maps to create the tree's within the environment, as my art skills are very limited. License for this asset is attached [here](https://drive.google.com/file/d/1DWGfcVE5nXsAkaPgqfGqf0lwesv6ug3N/view).

### Power Ups (Nicholas Phan)

We had decided to create a sense of Scaleability in the game by implementing powerups! We have these powerups scale the user's stats via a multiplicative value, and allowed for the players to have freedom of creating a build to last against these zombies! I was in charge of drawing the powerups and as a group, agreed that we would have four powerups: Health, Damage, Range, and Speed!

#### Below are the PowerUps!

| Health                                                                                                                                                                                                                                         | Damage                                                                                                                                                                                                                                 | Range                                                                                                                                                                                                                                        | Speed                                                                                                                                                                                                                                         |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Insert Health Here.](https://cdn.discordapp.com/attachments/591185804630687744/1220609948610854952/Health_Powerup.gif?ex=660f9099&is=65fd1b99&hm=edb9a84de3f5e24624ffff8d6f3ca0319114b08b4f2f8d59006a2be5157788e8& "Luffy's Favorite Food!") | ![Insert Damage Here.](https://cdn.discordapp.com/attachments/1199392620959498400/1218790900788891719/Hand_Powerup.gif?ex=6608f27a&is=65f67d7a&hm=e4cc46206664b1488c2e9ecfff3f6eed358beaa7cdc2d3144c44a016262a28e7& "He's got hands!") | ![Insert Range Here.](https://cdn.discordapp.com/attachments/1199392620959498400/1218793946818412605/Range_Powerup.gif?ex=6608f551&is=65f68051&hm=890f49f40645ee3c5bffbae0f336da2a534ab9b3c32ba9172e467270919634a8& "Probably the most OP!") | ![Insert Speed Here.](https://cdn.discordapp.com/attachments/591185804630687744/1220609947922993172/Speed_Buff.gif?ex=660f9099&is=65fd1b99&hm=4242b01ccab4cfdfa2f7b3208a39b7d1752e979426e37f472931a469edc6e194& "Based on a real life shoe!") |

I chose to use these icons as a way to represent the given stats as I felt like it was easy for players to understand! Meat = Health, Hand = Damage (cause they got hands), Crosshair for range (though it can be confused for a shield), and Red Boots for speed!

### Animator and Animation Implementation (Jason)

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
  - Also created a animation for pop up text indicating to the player what power is picked up and it's use.<br>
    !["Pick Up Notification".](https://media.discordapp.net/attachments/1199392620959498400/1220824961845825546/Unity_3Wb3GSNhWK.gif?ex=661058d8&is=65fde3d8&hm=02c53f0224cfddc36190fbb66ef4d3222d38bccf90c75f75527334141363af49&=)

## Sub Roles

### Game Feel (Jason)

- Made sure the whole death animation plays for zombies.
- Accurately/ Modified placed collisions, so players weren't getting collided with the air.
- Made the player blink red, as it was confusing when the player was taking damage.
- Added hold down `Mouse1/Fire1`, as player was having to manually spam to kill enemies.
- After testing, we found zombies getting stuck. Decided to change the map to stop choke points where zombies commonly got stuck.
- Added Pick up sound and Indicator to pick ups as it was confusing what the pick ups upgraded. The pickup sound creates a more auditory and responsive gameplay.

### Audio (Nicholas Phan)

In order to control the sounds in the game, we utilized the `SoundManager.cs` from [exercise 1](https://github.com/dr-jam/CommandPatternExercise) and was able to implement sounds and music for the game. I created a global `GameObject` as a way to make a similar object hierarchy that the exercises did to maintain audio, and would have the audio play on specific key events such as: When the player punches, when zombies spawn (little toaster dings), when players pick up a powerup, etc.

For Audio choices, I found primarily royalty free music and took sound effects from other games and media to support what we wanted.

#### Music (Nicholas Phan)

For Zompunch I found two songs that were Royalty Free and decided it fit the theme of the game. The songs are ["Royalty Free Heavy Metal Instrumental - Game Over - Jacob Lizotte"](https://www.youtube.com/watch?v=DpxZ5PHa6xo) and ["Violent Zombie Annihilation Music Bed of Razors Royalty Free No Copyright Music"](https://www.youtube.com/watch?v=VjFMP9KcqOU)

#### SFX (Nicholas Phan)

For sound effects, we had a couple of scrapped sounds that we didn't use, but for the most part we have sound effects that focus on the Punch, the spawning of zombies, and the powerups!

Here is the [Punch Sound](https://www.youtube.com/watch?v=lwYL2vs9HL4) and the
[Round Start Sound](https://www.youtube.com/watch?v=KS85lRtQ_pk) for the toasts. I picked this specific punch sound as it allows for a sense of "Power" within the punch, and for the round start sound, I thought it would fit the theme of how the toasts are spawning out of a toaster!

For the [Powerup Sound](https://pixabay.com/sound-effects/), we got it off this website as it allows for royalty free use.

### Narrative Design (Eric Barron and Nicholas Phan)

Talking with Eric about the Narrative design, we ended up going for a post-apocalyptic UC Davis, where a mysterious Food Poisoning disease called "Toast-Vid 19" had spread throughout the campus. Upon this disease spreading, it created a spiral of transformations of UC Davis Students, morphing them into different classes of "Toast Zombies"

Our design around a UC Davis toast outbreak allowed us to create all assets around the toast prefab. Most of the other teammates helped with the narrative design including the SFX / Audio / Music / Art. Since my main role was Game Logic, most of my narrative design implementations focused on creating the game's assets.

[Zombie Creation](https://github.com/cabatchi/ECS179zomPunch/commit/7dcbfec3710a64839ab3d0a966df419287858418) - Creating the Zombies and Spawners

### Press Kit and Trailer (Keith Low)

**Press Kit: [https://keith-loww.github.io/zompunch-press-kit/](https://keith-loww.github.io/zompunch-press-kit/)**

To align the press kit with the game's theme, I opted for a custom website built using Figma mockups. This approach ensured a cohesive visual experience between the press kit and the game itself.

The selected screenshots served to comprehensively showcase the core aspects of the game:

- **User Interface:** Screenshots of the main menu and the item store provided viewers with a clear understanding of the game's interface and navigation.
- **Visual Style:** The inclusion of a screenshot highlighting the tile-set effectively communicated the game's visual aesthetic.
- **Enemy Variety:** Screenshots featuring different enemy types offered a glimpse into the range of adversaries players will encounter.
- **Gameplay Core:** The inclusion of the game over screen provided context for the overall game flow.

In addition to the foundational elements, screenshots depicting the player swarmed by numerous zombies effectively conveyed the game's core mechanic - a "one vs. many" survival experience where players must overcome overwhelming odds.

**Trailer: [https://www.youtube.com/watch?v=E4mrN1o4A_c](https://www.youtube.com/watch?v=E4mrN1o4A_c)**

The game trailer prioritizes establishing the dark, apocalyptic atmosphere of the game. To achieve this, the trailer leverages the main theme music, which effectively sets the tone from the outset. The trailer's opening sequence is designed to quickly immerse viewers in the protagonist's situation, further amplifying the overall tone.

The core gameplay mechanics are presented through carefully selected snippets. These snippets highlight:

- **Movement:** The player character's agility and movement capabilities are showcased.
- **Combat:** Viewers get a glimpse of the punching mechanic, a core offensive option.
- **Evasion:** The trailer incorporates clips demonstrating the "rolling" mechanic, used to skillfully evade enemy attacks.

Beyond the basics, the trailer expands its scope by showcasing additional elements:

- **Variety of Enemies:** Clips featuring different enemy types pique the viewer's interest and hint at the range of challenges to overcome.
- **Strategic Resource Management:** The inclusion of the shop scene subtly introduces the concept of acquiring power-ups to enhance the player's chances of survival.
- **Chaotic Encounters:** Action-packed gameplay sequences effectively convey the overwhelming nature of the game's "survival" aspect.

By emphasizing the "play again" aspect in the trailer, the goal is to highlight the game's "arcade-like" qualities, encouraging players to anticipate multiple playthroughs and hone their skills.