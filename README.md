# 🏀 Hoop Tactics
A grid-based turn-based basketball strategy prototype built in Unity.  
Designed to showcase advanced gameplay system design, real-time UI interaction, turn management logic, and core AI mechanics — blending sports with tactical RPG elements.

👉 **Live Demo:** [Play on GitHub Pages](https://mateenaminian.github.io/Hoop-Tactics-Game/)

---

## 🎯 Game Concept

Hoop Tactics combines basketball fundamentals with tactical turn-based gameplay. Players control a 3v3 team on a grid-based court where movement, positioning, and timing impact shot success, pass accuracy, and defensive pressure.

Built fully from scratch to prototype and demonstrate:
- Tactical turn sequencing
- Stat-based game logic
- Probabilistic shot mechanics
- Real-time mini-games for shot/pass accuracy

---

## 🚀 Core Features

- 🟩 **Tilemap Grid Engine:** 12x6 grid (72 total tiles) with movement range highlights and pathfinding
- 🧮 **Stat-Driven Gameplay:**
  - 3 player positions: Guard, Forward, Center — each with unique stat profiles and action advantages
  - Shooting, rebounding, passing all dynamically calculated per player role
- 🔀 **Action System:** 
  - Click-to-move
  - Click-to-pass with targeting
  - Click-to-shoot with probability UI overlay
- 🎯 **Mini-Games for Actions:**
  - **Shooting:** Time the shot at the apex of jump for higher accuracy (side profile animation)
  - **Passing:** Metronome-style timing mechanic to increase pass accuracy
- 🔄 **Turn-Based GameManager:** 
  - Handles turn state, action selection, and sequential team execution

---

## 🎮 Development Highlights

- **Unity Tilemap & Pathfinding** for grid system
- **Custom UI & Input Handlers** for smooth gameplay loop
- **GameManager Controller** to manage turn sequencing and player state
- **Modular Code Structure** for future expansions (AI Opponent Logic, Campaign Mode, Stat Upgrades)

---

## 🛠️ Tech Stack

| Tech       | Usage                 |
|------------|------------------------|
| `Unity`    | Core engine (2021.x+)  |
| `C#`       | Gameplay scripting     |
| `Tilemap`  | Court layout and grid  |
| `Unity UI` | Action menus & overlays|

---

## 📸 Screenshots

| Grid Gameplay | Shot UI | Pass Timing |
|----------------|---------|--------------|
| *[Insert Screenshots Here]* | *[Insert]* | *[Insert]* |

> 📁 *Assets and UI elements are for prototype demonstration.*

---

## 💡 Learning Goals

- Implement turn-based systems architecture
- Procedural stat-based gameplay balancing
- Mini-game integration within turn-based systems
- Core game loop polish (movement, action menus, UI feedback)

---

## 🧪 Run Locally

1. Clone the repo: git clone https://github.com/MateenAminian/Hoop-Tactics-Game.git
2. Open in Unity (2021.x+ recommended)
3. Load the main scene.
4. Press ▶️ to play locally or simply play the Live Demo here: https://mateenaminian.github.io/Hoop-Tactics-Game/

👤 Author
Mateen Aminian
Senior Software Engineer — AI Systems, Full-Stack, & Game Development
📍 Los Angeles, CA
🔗 Portfolio Website
📫 mateenaminian@gmail.com

📝 License
This project is open-source and for demo/prototype purposes only.
All placeholder assets are used for development showcase.
