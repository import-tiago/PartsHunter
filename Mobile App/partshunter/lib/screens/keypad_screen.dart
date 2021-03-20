//Flutter
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';

import 'package:firebase_database/firebase_database.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:partshunter/screens/register_screen.dart';
import 'package:partshunter/screens/search_screen.dart';

//Application
import 'dart:convert';

import 'package:partshunter/stores/store.dart';

import 'package:flutter_numpad_widget/flutter_numpad_widget.dart';

//Screens

//Stores

class KeypadScreen extends StatefulWidget {
  @override
  _KeypadScreenState createState() => _KeypadScreenState();
}

class _KeypadScreenState extends State<KeypadScreen> {
  
  PartsDatabaseStore store = PartsDatabaseStore();

  bool outRange = false;
  int Current_BottomNavigation_Index = 1;

  void Change_BottomNavigation_Index(int index) {


if(index != 2)
    setState(() => Current_BottomNavigation_Index = index);
    
    switch (index) {
      case 0:
        store.Set_Hardware_Device(-1);
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => SearchScreen()));
        break;
      
      case 1:
      store.Set_Hardware_Device(-1);
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => RegisterScreen()));
        break;
    }
  }

  @override
  Widget build(BuildContext context) {
    
    PartsDatabaseStore store = PartsDatabaseStore();

    final _controller = NumpadController(format: NumpadFormat.NONE);
    
    
  void _controllerListener() =>  store.Set_Hardware_Device(_controller.rawNumber) ;
  
  _controller.addListener(_controllerListener);

    return Scaffold(
        appBar: AppBar(),
        bottomNavigationBar: BottomNavigationBar(
          type: BottomNavigationBarType.fixed,
          currentIndex: 2,
          onTap: (int index) => Change_BottomNavigation_Index(index),
          unselectedItemColor: Colors.grey,
          selectedItemColor: Color.fromRGBO(65, 91, 165, 1.0),
          items: [
            BottomNavigationBarItem(
              icon: Icon(Icons.search),
              label: "Search",
            ),
            BottomNavigationBarItem(icon: Icon(Icons.library_add), label: "New"),
            BottomNavigationBarItem(icon: Icon(Icons.keyboard_hide_outlined), label: "Keypad"),
          ],
        ),
        body: Column(children: <Widget>[
          Padding(padding: EdgeInsets.all(10), child:
           NumpadText(

             controller: _controller, 
             style: TextStyle(fontSize: 40))),
          Expanded(
            child: Numpad(

              controller: _controller,
              
               buttonTextSize: 40),

               ),
          Observer(builder: (_){
            return outRange == false ? Text("") : Text("Error");
          })
        ]));
  }





}
