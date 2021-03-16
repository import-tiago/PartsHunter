//Flutter
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';

import 'package:firebase_database/firebase_database.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:partshunter/screens/keypad_screen.dart';
import 'package:partshunter/screens/search_screen.dart';

//Application
import 'dart:convert';

import 'package:partshunter/stores/store.dart';

//Screens

//Stores

class RegisterScreen extends StatefulWidget {
  @override
  _RegisterScreenState createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  int Current_BottomNavigation_Index = 1;

  void Change_BottomNavigation_Index(int index) {
    setState(() => Current_BottomNavigation_Index = index);
    switch (index) {
      case 0:
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => SearchScreen()));
        break;
    
      case 2:
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => KeypadScreen()));
        break;
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(),
        bottomNavigationBar: BottomNavigationBar(
          type: BottomNavigationBarType.fixed,
          currentIndex: 1,
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
        body: Column(children: <Widget>[]));
  }
}
