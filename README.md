<p align="center">
  <img align="middle" src=".\logo.png">
</p>

# Wow Client Switcher
A compact overlay used to focus the desired **World of Warcraft** client in a multi-boxing setup.

## Why this app ?
Previously, I used a software called [eve-o-preview](https://github.com/EveOPlus/eve-o-preview) for **Eve Online** to switch between opened clients.

I aimed to replicate the same (but more limited) functionality for **World of Warcraft**.

## Supported Platforms
- Windows 10 / 11

## Installation
Download the latest release [here](https://github.com/SebastienDuruz/WowSwitcher/releases).

## Usage
Upon launching the application, a draggable window will open.

The application automatically scans for open World of Warcraft clients every X seconds.

You can click on a client to bring it to the foreground.

### Example
Here is an example of the overlay with two clients open.

![two clients example](https://github.com/SebastienDuruz/WowSwitcher/blob/master/Screenshots/example_2clients.png)

## Settings
The app's settings can be found in the following folder:
```
C:\Users\Sebastien\AppData\Local\WowClientSwitcher
```
**You need to start the app once to generate the *settings.json* file.**
### settings.json
| Parameter               | Usage                                                                        |
|-------------------------|------------------------------------------------------------------------------|
| **WowClientIdentifier** | The name of the wow client windows (useful for private servers, for example) |
| **PaddingX**            | The number of pixel to add to left and right of each client button           |
| **PaddingY**            | The number of pixel to add to top and bottom of each client button           |
| **RefreshTimeout**      | The number of seconds to refresh the wow clients                             |

If you encounter any issues with the config file, simply **delete the settings.json file** and restart the app.
## License
**WowClientSwitcher** is open-sourced software licensed under [GNU General Public License v3.0](https://github.com/SebastienDuruz/WowSwitcher/blob/master/LICENCE).