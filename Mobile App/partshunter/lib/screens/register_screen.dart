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
  PartsDatabaseStore store = PartsDatabaseStore();

  @override
  void initState() {
    super.initState();
    store.Get_Firebase_and_Convert_to_JSON();
  }

  String Last_Register_Category = "";
  String Last_Register_Description = "";
  String Last_Register_Drawer = "";

  bool checkbox_state = false;

  String Current_Selected_DropDown_Value;

  int Current_BottomNavigation_Index = 1;

  void Change_BottomNavigation_Index(int index) {
    setState(() => Current_BottomNavigation_Index = index);
    switch (index) {
      case 0:
      store.Set_Hardware_Device(-1);
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => SearchScreen()));
        break;

      case 2:
      store.Set_Hardware_Device(-1);
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
        body: Column(children: <Widget>[
          Container(
            margin: EdgeInsets.only(right: 10, left: 0, top: 10, bottom: 10),
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: <Widget>[
                checkbox_state ? buildTextField() : buildDropDown(),
                Wrap(
                  spacing: -8.0,
                  direction: Axis.horizontal,
                  alignment: WrapAlignment.center,
                  crossAxisAlignment: WrapCrossAlignment.center,
                  children: [
                    Checkbox(
                        activeColor: Color.fromRGBO(41, 55, 109, 1.0),
                        value: checkbox_state,
                        onChanged: (value) {
                          setState(() {
                            checkbox_state = value;
                          });
                        }),
                    Text(
                      "new",
                      style: TextStyle(fontSize: 16, color: Colors.grey[600]),
                    ),
                  ],
                )
              ],
            ),
          ),
          Container(
              height: 40,
              margin: EdgeInsets.only(right: 10, left: 10, top: 10),
              child: TextField(
                keyboardType: TextInputType.visiblePassword,
                onChanged: (input) => store.Register_Description = input,
                textAlign: TextAlign.left,
                decoration: InputDecoration(
                  hintText: 'Description',
                  border: const OutlineInputBorder(),
                  contentPadding: EdgeInsets.only(left: 10, right: 10),
                ),
              )),
          Container(
              height: 40,
              margin: EdgeInsets.only(right: 10, left: 10, top: 20),
              child: TextField(
                keyboardType: TextInputType.number,                
                onChanged: (input) => store.Register_Drawer = input,
                textAlign: TextAlign.left,
                decoration: InputDecoration(
                  hintText: 'Drawer',
                  border: const OutlineInputBorder(),
                  contentPadding: EdgeInsets.only(left: 10, right: 10),
                ),
              )),
          Container(
            margin: EdgeInsets.all(10),
            width: double.infinity,
            child: TextButton(
                onPressed: () async {
                  FocusScope.of(context).unfocus();

                  if (Last_Register_Description != store.Register_Description && Last_Register_Drawer != store.Register_Drawer) {
                    if (await store.createData(store.Register_Category, store.Register_Description, store.Register_Drawer) == true) {
                      ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text("Success")));

                      Last_Register_Category = store.Register_Category;
                      Last_Register_Description = store.Register_Description;
                      Last_Register_Drawer = store.Register_Drawer;
                    } else
                      ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text("Fail")));
                  } else
                    ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text("Fail! Some Description and/or Drawer")));
                },
                child: Text(
                  'SAVE',
                  style: TextStyle(fontSize: 16),
                ),
                style: ButtonStyle(
                    backgroundColor: MaterialStateProperty.all<Color>(Color.fromRGBO(41, 55, 109, 1.0)),
                    side: MaterialStateProperty.all(BorderSide(width: 2, color: Color.fromRGBO(41, 55, 109, 1.0))),
                    foregroundColor: MaterialStateProperty.all(Colors.white),
                    padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 5, horizontal: 20)),
                    textStyle: MaterialStateProperty.all(TextStyle(fontSize: 30)))),
          ),
        ]));
  }

  Widget buildDropDown() {
    return Expanded(
      child: Container(
        height: 40,
        margin: EdgeInsets.only(left: 10),
        padding: const EdgeInsets.only(left: 10.0, right: 10.0),
        decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(5.0), border: Border.all(color: Colors.grey[600], style: BorderStyle.solid, width: 0.80)),
        child: Observer(builder: (_) {
          return DropdownButton<String>(
            underline: SizedBox(),
            hint: Text("Choose an existing category"),
            isExpanded: true,
            value: Current_Selected_DropDown_Value,
            onChanged: (String newValue) {
              setState(() {
                Current_Selected_DropDown_Value = newValue;
              });

              store.Register_Category = newValue;
            },
            items: store.dropDownMenuItems,
          );
        }),
      ),
    );
  }

  Widget buildTextField() {
    return Expanded(
      child: Container(
          height: 40,
          margin: EdgeInsets.only(right: 10, left: 10),
          child: TextField(
            onChanged: (input) {
              input = input.toUpperCase();
              store.Register_Category = input;
            },
            textAlign: TextAlign.left,
            decoration: InputDecoration(
              hintText: 'Type a new category',
              border: const OutlineInputBorder(),
              contentPadding: EdgeInsets.only(left: 10, right: 10),
            ),
          )),
    );
  }
}
