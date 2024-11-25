# PartsHunter

**PartsHunter** is an electronic component organization system designed for efficiency and precision. It consists of three core modules:


1. [**Windows Application**](#windows-application): A user-friendly interface for searching and managing components by description.
2. [**Hardware Device**](#hardware-device): A communication module that interacts with the Windows application to activate LEDs, pinpointing the location of each component.
3. [**Mechanical Assembly**](#mechanical-assembly): A storage system that organizes components across dedicated slots.

---
## Video - Demo

<p align="center"><a href="https://vimeo.com/1032888161"><img src="Assets/VideoThumbnail.png"" title="Watch the video" alt="Watch the video"></a></p>

## How It Works
- When a search query is entered in the Windows application, an **SQLite database** is queried to retrieve relevant results.  
- The user selects the desired component(s) from the displayed results, triggering **REST requests** to the hardware device via Wi-Fi.  
- Powered by an **ESP32 web server**, the hardware processes these requests and illuminates the LEDs corresponding to the storage slots containing the selected components.  

This integrated solution streamlines component management, saving time and reducing errors in locating items.

## Flow Overview
<img src="Assets/flow_overview.png">

---

## Windows Application
<img src="Assets/ui_preview.png">

## Hardware Device
<img src="Assets/circuit_diagram.png">

## Mechanical Assembly
<img src="Assets/mechanical_preview.png">

### Contributing
0. Give this project a :star:
1. Create an issue and describe your idea.
2. [Fork it](https://github.com/import-tiago/PartsHunter/fork).
3. Create your feature branch (`git checkout -b my-new-feature`).
4. Commit your changes (`git commit -a -m "Added feature title"`).
5. Publish the branch (`git push origin my-new-feature`).
6. Create a new pull request.
7. Done! :heavy_check_mark:

<p xmlns:cc="http://creativecommons.org/ns#" xmlns:dct="http://purl.org/dc/terms/"><a property="dct:title" rel="cc:attributionURL" href="https://github.com/import-tiago/PartsHunter">PartsHunter</a> by <a rel="cc:attributionURL dct:creator" property="cc:attributionName" href="http://mailto:tiagodepaulasilva@gmail.com">Tiago Silva</a> is licensed under <a href="https://creativecommons.org/licenses/by-nc-sa/4.0/?ref=chooser-v1" target="_blank" rel="license noopener noreferrer" style="display:inline-block;">CC BY-NC-SA 4.0<img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/cc.svg?ref=chooser-v1" alt=""><img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/by.svg?ref=chooser-v1" alt=""><img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/nc.svg?ref=chooser-v1" alt=""><img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/sa.svg?ref=chooser-v1" alt=""></a></p>
