# PartsHunter

| <img src="Assets/modules_overview.png" width="5000"> | **PartsHunter** is an electronic component organization system composed of three main modules: a mechanical assembly for component storage, a Windows application that allows the user to search for the desired component by description, and a hardware device that remotely communicates with the Windows app and activates LEDs to indicate the location of each item based on the search performed. When a search is executed in the application, an SQLite database is queried, and the results are displayed on the screen. The user can then select the desired component(s), triggering REST POST requests to the hardware device, which uses an ESP32 as a web server. These requests are processed, and the corresponding LEDs are lit, indicating the slots where each component is located. |
|--------------------------|--------------------------------------------------------------|

## Usage Flow Overview
<img src="Assets/flow_overview.png" alt="Flow Overview">

## Hardware Device Circuit Diagram
<img src="Assets/circuit_diagram.png" alt="Flow Overview">

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
